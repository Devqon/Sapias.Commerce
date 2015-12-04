using System;

namespace Sapias.Commerce.Models {
    [Serializable]
    public sealed class ShoppingCartItem {
        public int ProductId { get; private set; }

        private int _quantity;
        public int Quantity {
            get { return _quantity; }
            set {
                if (value < 0) {
                    _quantity = 0;
                }
                else {
                    _quantity = value;
                }

            }
        }

        public ShoppingCartItem() {
        }

        public ShoppingCartItem(int productId, int quantity = 1) {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}