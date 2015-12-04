using Orchard.ContentManagement.Drivers;
using Sapias.Commerce.Models;
using Orchard.ContentManagement;
using Sapias.Commerce.Services;

namespace Sapias.Commerce.Drivers {
    public class ProductPartDriver : ContentPartDriver<ProductPart> {
        private IProductService _productService;

        public ProductPartDriver(IProductService productService) {
            _productService = productService;
        }

        protected override string Prefix {
            get { return "Product"; }
        }

        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper) {
            return Combined(
                ContentShape("Parts_Product_SummaryAdmin", () => shapeHelper.Parts_Product_SummaryAdmin(
                    Price: part.Price,
                    Sku: part.Sku,
                    DiscountPrice: part.DiscountPrice,
                    Inventory: part.Inventory,
                    ContentPart: part
                )),
                ContentShape("Parts_Product", () => shapeHelper.Parts_Product(
                    Price: part.Price,
                    Sku: part.Sku,
                    DiscountPrice: part.DiscountPrice,
                    Inventory: part.Inventory
                )),
                ContentShape("Parts_Product_AddButton", () => shapeHelper.Parts_Product_AddButton(
                    ProductId: part.Id,
                    CanAdd: _productService.CanOrderProduct(part)
                ))
            );
        }

        protected override DriverResult Editor(ProductPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Product_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/Product", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(ProductPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}