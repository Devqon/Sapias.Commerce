using Orchard.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace Sapias.Commerce.Models {
    public class ProductPart : ContentPart<ProductPartRecord> {
        [Required]
        public string Sku {
            get { return Retrieve(x => x.Sku); }
            set { Store(x => x.Sku, value); }
        }

        [Required]
        public decimal Price {
            get { return Retrieve(x => x.Price); }
            set { Store(x => x.Price, value); }
        }

        public decimal DiscountPrice {
            get { return Retrieve(r => r.DiscountPrice, -1); }
            set { Store(r => r.DiscountPrice, value); }
        }

        public int Inventory {
            get { return Retrieve(r => r.Inventory); }
            set { Store(r => r.Inventory, value); }
        }
    }
}