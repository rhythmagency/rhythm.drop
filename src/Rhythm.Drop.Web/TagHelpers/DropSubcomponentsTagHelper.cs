namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Subcomponents;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;
using System.Threading.Tasks;

/// <summary>
/// A tag helper for rendering subcomponents.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
/// <param name="themeHelper">The theme helper.</param>
[HtmlTargetElement("drop-subcomponents", TagStructure = TagStructure.WithoutEndTag)]
public sealed class DropSubcomponentsTagHelper(IDropSubcomponentsTagHelperRenderer tagHelperRenderer, IThemeHelper themeHelper) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropSubcomponentsTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// The theme helper.
    /// </summary>
    private readonly IThemeHelper _themeHelper = themeHelper;

    /// <summary>
    /// Gets or sets the model for the subcomponents.
    /// </summary>
    [HtmlAttributeName("model")]
    public IReadOnlyCollection<ISubcomponent> Model { get; set; } = Array.Empty<ISubcomponent>();

    /// <summary>
    /// Gets or sets an optional section of where this subcomponent is rendered.
    /// </summary>
    /// <remarks>This could be used for distinquishing between subcomponents in the main content versus a modal.</remarks>
    [HtmlAttributeName("section")]
    public string? Section { get; set; }

    /// <summary>
    /// Gets or sets the tag name for the container.
    /// </summary>
    [HtmlAttributeName("tag-name")]
    public string? TagName { get; set; }

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
        var rendererContext = new DropSubcomponentsTagHelperRendererContext(Model, theme, TagName, ViewContext, Section);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}