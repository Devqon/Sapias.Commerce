using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Sapias.Commerce.Models;

namespace Sapias.Commerce.Migrations {
    public class ProductMigrations : DataMigrationImpl {
        public int Create() {

            SchemaBuilder.CreateTable(typeof(ProductPartRecord).Name, table => table
               .ContentPartRecord()

               .Column<string>("Sku", col => col.WithLength(50))
               .Column<decimal>("Price")
               .Column<decimal>("DiscountPrice")
               .Column<int>("Inventory"));

            ContentDefinitionManager.AlterPartDefinition(typeof(ProductPart).Name, part => part
               .Attachable());


            // Test types data
            ContentDefinitionManager.AlterTypeDefinition("Book", type => type
                .WithPart(typeof(ProductPart).Name)
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("TagsPart")
                .WithPart("AutoroutePart", builder => builder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "false")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Title', Pattern: '{Content.Slug}', Description: 'my-book'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .Creatable()
                );

            ContentDefinitionManager.AlterTypeDefinition("DVD", type => type
                .WithPart(typeof(ProductPart).Name)
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("TagsPart")
                .WithPart("AutoroutePart", builder => builder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "false")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Title', Pattern: '{Content.Slug}', Description: 'my-dvd'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .Creatable()
                );

            return 1;
        }

        public int UpdateFrom1() {

            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithPart(typeof(ShoppingCartWidgetPart).Name)
                .WithSetting("Stereotype", "Widget"));

            return 2;
        }
    }
}