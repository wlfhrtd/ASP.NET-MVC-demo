using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;


namespace Mvc.TagHelpers
{
    public class ColumnListTagHelper : TagHelper
    {
        public const string NumberOfColumnsAttributeName = "asp-number-of-columns";

        private const string ForAttributeName = "asp-for";

        private const string ViewComponentAttributeName = "asp-view-component";

        [HtmlAttributeName(NumberOfColumnsAttributeName)]
        public int NumberOfColumns { get; set; }

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(ViewComponentAttributeName)]
        public string ViewComponentName { get; set; }

        private readonly IViewComponentHelper viewComponentHelper;

        [HtmlAttributeNotBound] // do not show in VS IntelliSense
        [ViewContext] // set ViewContext prop once constructed
        public ViewContext ViewContext { get; set; }


        public ColumnListTagHelper(IViewComponentHelper viewComponentHelper)
        {
            this.viewComponentHelper = viewComponentHelper;
        }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (output == null) throw new ArgumentNullException(nameof(output));

            if (NumberOfColumns < 1 || NumberOfColumns > 12)
                throw new ArgumentOutOfRangeException(
                    "NumberOfColumns", "Number of columns must be at least 1 and at most 12.");

            if (For == null)
            {
                output.SuppressOutput();
                return;
            }

            var collection = For.Model as ICollection;
            if (collection == null) throw new ArgumentNullException("For", "Model Expression must be a collection.");

            ((IViewContextAware)viewComponentHelper).Contextualize(ViewContext);

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "container-fluid");

            int columnsInRow = 1;
            int rowsDone = 0;
            int numberOfItemsDone = 0;
            int numberOfExtraColumnsInLastRow = 0;

            int numberOfRows = collection.Count / NumberOfColumns;

            foreach (var item in collection)
            {
                if (columnsInRow == 1) output.Content.AppendHtml(@"<div class=""row"">");
                output.Content.AppendHtml(GetColumnDivTag());
                var viewContent = await viewComponentHelper.InvokeAsync(ViewComponentName, item);
                output.Content.AppendHtml(viewContent);
                output.Content.AppendHtml("</div>");

                bool isLastItem = collection.Count == numberOfItemsDone + 1;
                if (columnsInRow == NumberOfColumns || isLastItem)
                {
                    if (isLastItem)
                    {
                        numberOfExtraColumnsInLastRow = NumberOfColumns - columnsInRow;
                        output.Content.AppendHtml(RenderExtraColumns(numberOfExtraColumnsInLastRow));
                    }

                    output.Content.AppendHtml("</div>");

                    columnsInRow = 1;
                    rowsDone++;
                }
                else
                {
                    columnsInRow++;
                }

                numberOfItemsDone++;
            }
        }
        // for empty data in last row
        private string RenderExtraColumns(int numberOfExtraColumnsInLastRow)
        {
            if (numberOfExtraColumnsInLastRow > 0)
            {
                StringBuilder builder = new();
                for (int i = 0; i < numberOfExtraColumnsInLastRow; i++)
                {
                    builder.Append(GetColumnDivTag());
                    builder.Append("</div>");
                }

                return builder.ToString();
            }

            return string.Empty;
        }
        // bootstrap grid has 12 columns
        private string GetColumnDivTag()
        {
            int colSpan = (int)Math.Round((double)(12 / NumberOfColumns));
            return string.Format(@"<div class=""col-xs-{0} col-sm-{0} col-md-{0} col-lg-{0}"">", colSpan);
        }
    }
}
