using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Sapias.Commerce.Models;

namespace Sapias.Commerce.Handlers {
    public class ProductPartHandler : ContentHandler {
        public ProductPartHandler(IRepository<ProductPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}