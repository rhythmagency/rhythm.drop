namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Elements;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using System.Threading.Tasks;

/// <summary>
/// A tag helper for rendering elements.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
/// <param name="themeHelper">The theme helper.</param>
[HtmlTargetElement("drop-element", TagStructure = TagStructure.WithoutEndTag)]
public sealed class DropElementTagHelper(IDropElementsTagHelperRenderer tagHelperRenderer, IThemeHelper themeHelper) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropElementsTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// The theme helper.
    /// </summary>
    private readonly IThemeHelper _themeHelper = themeHelper;

    /// <summary>
    /// Gets or sets the model for the element.
    /// </summary>
    [HtmlAttributeName("model")]
    public IElement? Model { get; set; } = null!;

    /// <summary>
    /// Gets or sets the index.
    /// </summary>
    /// <remarks>This is useful if you want to manually render a collection of widgets.</remarks>
    [HtmlAttributeName("index")]
    public int Index { get; set; } = CollectionMetaData.FirstItemIndex;

    /// <summary>
    /// Gets or sets an optional section of where this element is rendered.
    /// </summary>
    /// <remarks>This could be used for distinquishing between elements in the main content versus a modal.</remarks>
    [HtmlAttributeName("section")]
    public string? Section { get; set; }

    /// <summary>
    /// Gets or sets the total number of elements.
    /// </summary>
    /// <remarks>This is useful if you want to manually render a collection of widgets.</remarks>
    [HtmlAttributeName("total")]
    public int Total { get; set; } = 1;

    /// <summary>
    /// Gets or sets the theme.
    /// </summary>
    [HtmlAttributeName("theme")]
    public string? Theme { get; set; }

    /// <summary>
    /// Gets the <see cref="ViewContext"/> of the executing view.
    /// </summary>
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; } = null!;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var theme = _themeHelper.GetValidTheme(Theme);
        var attributes = output.Attributes.ToHtmlAttributeCollection();
        var rendererContext = new DropElementTagHelperRendererContext(Model, theme, Index, Total, attributes, ViewContext, Section);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}