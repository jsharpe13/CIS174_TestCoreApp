using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CIS174_TestCoreApp
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("submit-button")]
    public class RazorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("type", "submit");

            string newClasses = "btn btn-primary";
            string oldClasses = output.Attributes["class"]?.Value?.ToString();
            string classes = (string.IsNullOrEmpty(oldClasses)) ?
                newClasses : $"{oldClasses} {newClasses}";
            output.Attributes.SetAttribute("class", classes);
        }
    }
}
