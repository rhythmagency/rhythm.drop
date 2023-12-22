namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Renders a collection of <see cref="IHtmlAttribute"/> on the current tag.
/// </summary>
[HtmlTargetElement(Attributes = "drop-attributes", TagStructure = TagStructure.Unspecified)]
public sealed class DropAttributesTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the attributes.
    /// </summary>
    [HtmlAttributeName("drop-attributes")]
    public IHtmlAttributeCollectionBase Attributes { get; set; } = ReadOnlyHtmlAttributeCollection.Empty();

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (Attributes.Count == 0)
        {
            return;
        }

        await Task.Run(() => RenderAttributes(output, Attributes));
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.PreDefault;

    private static void RenderAttributes(TagHelperOutput output, IHtmlAttributeCollectionBase attributes)
    {
        foreach (var attribute in attributes)
        {
            if (TryGetClasses(attribute, out var classes))
            {
                output.AddClasses(classes);
            }
            else
            {
                output.Attributes.SetAttribute(attribute.Name, attribute.Value);
            }
        };
    }

    private static bool TryGetClasses(IHtmlAttribute attribute, [NotNullWhen(true)] out string[]? classes)
    {
        if (attribute.Value is null || attribute.Name.Equals("class", StringComparison.OrdinalIgnoreCase) is false)
        {
            classes = default;
            return false;
        }

        var valueAsString = attribute.Value.ToString();

        if (string.IsNullOrEmpty(valueAsString))
        {
            classes = default;
            return false;
        }

        classes = valueAsString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return classes.Length > 0;
    }
}