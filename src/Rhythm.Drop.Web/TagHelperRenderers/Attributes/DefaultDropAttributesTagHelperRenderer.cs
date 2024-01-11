namespace Rhythm.Drop.Web.TagHelperRenderers.Attributes;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropAttributesTagHelperRenderer"/>.
/// </summary>
internal sealed class DefaultDropAttributesTagHelperRenderer : IDropAttributesTagHelperRenderer
{
    /// <inheritdoc/>
    public async Task RenderAsync(IHtmlAttributeCollectionBase? model, TagHelperContext context, TagHelperOutput output)
    {
        if (model is null || model.Count == 0)
        {
            return;
        }

        await Task.Run(() => RenderAttributes(output, model));
    }

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