﻿using Orchard;
using Orchard.Mvc;
using Orchard.Themes;
using Sapias.Commerce.Models;
using Sapias.Commerce.Services;
using Sapias.Commerce.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sapias.Commerce.Controllers {
    public class ShoppingCartController : Controller {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrchardServices _services;

        public ShoppingCartController(IShoppingCart shoppingCart, IOrchardServices services) {
            _shoppingCart = shoppingCart;
            _services = services;
        }

        [HttpPost]
        public ActionResult Add(int id) {

            // Add the specified content id to the shopping cart with a quantity of 1.
            _shoppingCart.Add(id, 1);

            // Redirect the user to the Index action
            return RedirectToAction("Index");
        }

        [Themed]
        public ActionResult Index() {

            // Create a new shape using the "New" property of IOrchardServices.
            var shape = _services.New.ShoppingCart(
                Products: _shoppingCart.GetProducts().Select(p => _services.New.ShoppingCartItem(
                    ProductPart: p.ProductPart,
                    Quantity: p.Quantity,
                    Title: _services.ContentManager.GetItemMetadata(p.ProductPart).DisplayText)
                ).ToList(),
                Total: _shoppingCart.Total(),
                Subtotal: _shoppingCart.Subtotal(),
                Vat: _shoppingCart.Vat()
            );

            // Return a ShapeResult
            return new ShapeResult(this, shape);
        }

        [HttpPost]
        public ActionResult Update(UpdateShoppingCartItemViewModel[] items) {
            UpdateShoppingCart(items);

            if (Request.IsAjaxRequest())
                return Json(true);

            //switch (command) {
            //    case "Checkout":
            //        return RedirectToAction("SignupOrLogin", "Checkout");
            //    case "ContinueShopping":
            //        break;
            //    case "Update":
            //        break;
            //}

            return RedirectToAction("Index");
        }

        public ActionResult GetItems() {
            var products = _shoppingCart.GetProducts();

            var json = new {
                items = products.Select(item => new {
                    // camelCase
                    id = item.ProductPart.Id,
                    title = _services.ContentManager.GetItemMetadata(item.ProductPart).DisplayText,
                    price = item.ProductPart.Price,
                    quantity = item.Quantity
                }).ToArray(),
                vat = _shoppingCart.Vat(),
                subTotal = _shoppingCart.Subtotal(),
                total = _shoppingCart.Total(),
                totalItems = products.Sum(p => p.Quantity)
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private void UpdateShoppingCart(IEnumerable<UpdateShoppingCartItemViewModel> items) {

            _shoppingCart.Clear();

            if (items == null)
                return;

            _shoppingCart.AddRange(items
                .Where(item => !item.IsRemoved)
                .Select(item => new ShoppingCartItem(item.ProductId, item.Quantity < 0 ? 0 : item.Quantity))
            );

            _shoppingCart.UpdateItems();
        }
    }
}