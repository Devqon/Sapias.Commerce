using Orchard.UI.Resources;

namespace Sapias.Commerce {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineScript("Webshop.ShoppingCartService").SetUrl("app/services/shoppingCartService.js");
            manifest.DefineScript("Webshop.ShoppingCartController").SetUrl("app/controllers/shoppingCartController.js").SetDependencies("Webshop.ShoppingCartService");
            manifest.DefineScript("Webshop").SetUrl("app/webshop.js").SetDependencies("jQuery", "AngularJS", "Webshop.ShoppingCartService", "Webshop.ShoppingCartController");
        }
    }
}