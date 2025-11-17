using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sismog.TagHelpers;

[HtmlTargetElement("a", Attributes = TargetAttributeName)]
public class CssClassForCurrentLink : TagHelper
{
    private const string TargetAttributeName = "asp-link-class";

    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    [HtmlAttributeName("class")]
    public string? Classes { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var action = context.AllAttributes["asp-action"].Value.ToString();
        var controller = context.AllAttributes["asp-controller"].Value.ToString();
        //<a class="nav-link" asp-controller="Home" asp-action="Index" asp-link-class="link-ativo">Principal</a>
        var thClasses = context.AllAttributes[TargetAttributeName].Value.ToString();

        var currAction = ViewContext?.HttpContext.Request.RouteValues["action"]?.ToString();
        var currController = ViewContext?.HttpContext.Request.RouteValues["controller"]?.ToString();

        if (action == currAction && controller == currController)
            Classes += $" {thClasses}";

        output.Attributes.Add("class", Classes);

        var attribute = context.AllAttributes[TargetAttributeName];
        _ = output.Attributes.Remove(attribute);
    }
}