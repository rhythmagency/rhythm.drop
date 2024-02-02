namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.MetaData.Components;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using System.Threading.Tasks;

/// <summary>
/// A tag helper for rendering modals.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
/// <param name="modalPersistenceHelper">The modal persistence helper.</param>
/// <param name="themeHelper">The theme helper.</param>
[HtmlTargetElement("drop-modals", TagStructure = TagStructure.WithoutEndTag)]
public sealed class DropModalsTagHelper(IDropComponentsTagHelperRenderer tagHelperRenderer, IModalPersistenceHelper modalPersistenceHelper, IThemeHelper themeHelper) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropComponentsTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// The modal persistence helper.
    /// </summary>
    private readonly IModalPersistenceHelper _modalPersistenceHelper = modalPersistenceHelper;

    /// <summary>
    /// The theme helper.
    /// </summary>
    private readonly IThemeHelper _themeHelper = themeHelper;

    /// <summary>
    /// Gets or sets an optional collection of models.
    /// </summary>
    /// <remarks>If no value is set the persisted modals for this request will be used instead.</remarks>
    [HtmlAttributeName("model")]
    public IReadOnlyCollection<IModal>? Model { get; set; } = null!;

    /// <summary>
    /// Gets or sets the tag name for the container.
    /// </summary>
    [HtmlAttributeName("tag-name")]
    public string? TagName { get; set; } = "div";

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    [HtmlAttributeName("level")]
    public int Level { get; set; } = ComponentMetaData.RootLevel;

    /// <summary>
    /// Gets or sets an optional section of where this component is rendered.
    /// </summary>
    /// <remarks>This could be used for distinquishing between components in the main content versus a modal.</remarks>
    [HtmlAttributeName("section")]
    public string? Section { get; set; }

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
        var modals = GetModals();
        var theme = _themeHelper.GetValidTheme(Theme);
        var renderContext = new DropComponentsTagHelperRendererContext(modals, Level, theme, TagName, ViewContext, Section);

        await _tagHelperRenderer.RenderAsync(renderContext, context, output);
    }

    private IReadOnlyCollection<IModal> GetModals()
    {
        if (Model is null)
        {
            return _modalPersistenceHelper.GetAll();
        }

        return Model;
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}