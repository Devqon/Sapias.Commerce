using Orchard.ContentManagement.Records;

namespace Sapias.Commerce.Models {
    public class ProductPartRecord : ContentPartRecord {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}