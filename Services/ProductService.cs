using Sapias.Commerce.Models;

namespace Sapias.Commerce.Services {
    public class ProductService : IProductService {
        public bool CanOrderProduct(ProductPart part) {
            return part.Inventory > 0;
        }
    }
}