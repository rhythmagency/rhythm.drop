﻿namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using System.Threading.Tasks;

/// <summary>
/// A tag helper for rendering components.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
/// <param name="themeHelper">The theme helper.</param>
[HtmlTargetElement("drop-modal")]
public sealed class DropModalTagHelper(IDropComponentsTagHelperRenderer tagHelperRenderer, IThemeHelper themeHelper) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropComponentsTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// The theme helper.
    /// </summary>
    private readonly IThemeHelper _themeHelper = themeHelper;

    /// <summary>
    /// Gets or sets the model for the component.
    /// </summary>
    [HtmlAttributeName("model")]
    public IModal? Model { get; set; } = null!;

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    [HtmlAttributeName("level")]
    public int Level { get; set; } = ComponentMetaData.RootLevel;

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
        var rendererContext = new DropComponentTagHelperRendererContext(Model, Level, theme, ComponentMetaData.FirstItemIndex, 1, attributes, ViewContext);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}