namespace Rhythm.Drop.Web.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A collection of extension methods that augment <see cref="TagHelperAttributeList"/>.
/// </summary>
public static class TagHelperAttributeListExtensions
{
    public static IReadOnlyHtmlAttributeCollection ToHtmlAttributeCollection(this TagHelperAttributeList attributes)
    {
        var attributesCollection = new HtmlAttributeCollection();
        foreach (var attribute in attributes)
        {
            attributesCollection.SetAttribute(attribute.Name, attribute.Value);
        }

        return attributesCollection.ToReadOnly();
    }
}
