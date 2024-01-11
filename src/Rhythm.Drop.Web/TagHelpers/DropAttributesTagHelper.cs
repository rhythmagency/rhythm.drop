namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Attributes;
using System.Threading.Tasks;

/// <summary>
/// Renders a collection of <see cref="IHtmlAttribute"/> on the current tag.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement(Attributes = "drop-attributes", TagStructure = TagStructure.Unspecified)]
public sealed class DropAttributesTagHelper(IDropAttributesTagHelperRenderer tagHelperRenderer) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropAttributesTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// Gets or sets the attributes.
    /// </summary>
    [HtmlAttributeName("drop-attributes")]
    public IHtmlAttributeCollectionBase Attributes { get; set; } = ReadOnlyHtmlAttributeCollection.Empty();

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await _tagHelperRenderer.RenderAsync(Attributes, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.PreDefault;
}