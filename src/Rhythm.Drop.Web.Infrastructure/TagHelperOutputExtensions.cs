namespace Rhythm.Drop.Web.Infrastructure;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

/// <summary>
/// A collection of extension methods that augment <see cref="TagHelperOutput"/>.
/// </summary>
public static class TagHelperOutputExtensions
{
    /// <summary>
    /// Adds multiple classes to a <see cref="TagHelperOutput"/>.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <param name="classes">The classes.</param>
    /// <remarks>This overload uses <see cref="HtmlEncoder.Default"/>.</remarks>
    public static void AddClasses(this TagHelperOutput output, string[] classes)
    {
        output.AddClasses(classes, HtmlEncoder.Default);
    }

    /// <summary>
    /// Adds multiple classes to a <see cref="TagHelperOutput"/>.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <param name="classes">The classes.</param>
    /// <param name="htmlEncoder">The HTML encoder.</param>
    public static void AddClasses(this TagHelperOutput output, string[] classes, HtmlEncoder htmlEncoder)
    {
        foreach (var @class in classes)
        {
            output.AddClass(@class, htmlEncoder);
        }
    }

    /// <summary>
    /// Supresses the <see cref="TagHelperOutput"/> or the tag if there is child content.
    /// </summary>
    /// <param name="output">The current <see cref="TagHelperOutput"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public static async Task SupressOutputOrTag(this TagHelperOutput output)
    {
        var content = await output.GetChildContentAsync();

        if (content.IsEmptyOrWhiteSpace)
        {
            output.SuppressOutput();
        }
        else
        {
            output.SurpressTag();
        }
    }

    /// <summary>
    /// Supresses the tag of the <see cref="TagHelperOutput"/>.
    /// </summary>
    /// <param name="output">The current <see cref="TagHelperOutput"/>.</param>
    public static void SurpressTag(this TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = string.Empty;
    }
}