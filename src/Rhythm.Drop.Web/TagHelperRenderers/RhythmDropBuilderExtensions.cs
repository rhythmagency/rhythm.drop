namespace Rhythm.Drop.Web.TagHelperRenderers;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using Rhythm.Drop.Web.TagHelperRenderers.Components;
using Rhythm.Drop.Web.TagHelperRenderers.Images;
using Rhythm.Drop.Web.TagHelperRenderers.Links;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to links.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Adds the default tag helper renderers to the <see cref="IRhythmDropBuilder"/>.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder AddTagHelperRenderers(this IRhythmDropBuilder builder)
    {
        return builder
            .SetDefaultDropComponentsTagHelperRenderer()
            .SetDefaultDropImageTagHelperRenderer()
            .SetDefaultDropLinkTagHelperRenderer();
    }

    /// <summary>
    /// Sets the default drop components tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropComponentsTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropComponentsTagHelperRenderer<DefaultDropComponentsTagHelperRenderer>();
    }

    /// <summary>
    /// Sets the default drop link tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropLinkTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropLinkTagHelperRenderer<DefaultDropLinkTagHelperRenderer>();
    }

    /// <summary>
    /// Sets the default drop image tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropImageTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropImageTagHelperRenderer<DefaultDropImageTagHelperRenderer>();
    }
}