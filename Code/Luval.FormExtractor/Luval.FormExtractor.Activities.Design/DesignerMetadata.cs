using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Luval.FormExtractor.Activities.Design.Designers;
using Luval.FormExtractor.Activities.Design.Properties;

namespace Luval.FormExtractor.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(FormExtraction), categoryAttribute);
            builder.AddCustomAttributes(typeof(FormExtraction), new DesignerAttribute(typeof(FormExtractionDesigner)));
            builder.AddCustomAttributes(typeof(FormExtraction), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
