namespace Rhythm.Drop.Web.Infrastructure;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A collection of extension methods that augment <see cref="TagHelperAttributeList"/>.
/// </summary>
public static class TagHelperAttributeListExtensions
{
    /// <summary>
    /// Converts a <see cref="TagHelperAttributeList"/> to a <see cref="IReadOnlyHtmlAttributeCollection"/>.
    /// </summary>
    /// <param name="attributes">The tag helper attributes.</param>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
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
