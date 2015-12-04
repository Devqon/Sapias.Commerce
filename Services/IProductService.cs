using Orchard;
using Sapias.Commerce.Models;

namespace Sapias.Commerce.Services {
    public interface IProductService : IDependency {
        bool CanOrderProduct(ProductPart part);
    }
}