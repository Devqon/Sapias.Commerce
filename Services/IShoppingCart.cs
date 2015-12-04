using System.Collections.Generic;
using Sapias.Commerce.Models;
using Orchard;

namespace Sapias.Commerce.Services {
    public interface IShoppingCart : IDependency {
        IEnumerable<ShoppingCartItem> Items { get; }

        void Add(int productId, int quantity = 1);
        void AddRange(IEnumerable<ShoppingCartItem> items);
        void Clear();
        ProductPart GetProduct(int productId);
        IEnumerable<ProductQuantity> GetProducts();
        int ItemCount();
        void Remove(int productId);
        decimal Subtotal();
        decimal Total();
        void UpdateItems();
        decimal Vat();
    }
}