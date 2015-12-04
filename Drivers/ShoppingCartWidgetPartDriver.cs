using Orchard.ContentManagement.Drivers;
using Sapias.Commerce.Models;

namespace Sapias.Commerce.Drivers {
    public class ShoppingCartWidgetPartDriver : ContentPartDriver<ShoppingCartWidgetPart> {

        protected override DriverResult Display(ShoppingCartWidgetPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_ShoppingCartWidget", () => shapeHelper.Parts_ShoppingCartWidget());
        }
    }
}