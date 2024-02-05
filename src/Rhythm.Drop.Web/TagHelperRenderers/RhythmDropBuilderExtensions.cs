namespace Rhythm.Drop.Web.TagHelperRenderers;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using Rhythm.Drop.Web.TagHelperRenderers.Attributes;
using Rhythm.Drop.Web.TagHelperRenderers.Components;
using Rhythm.Drop.Web.TagHelperRenderers.Images;
using Rhythm.Drop.Web.TagHelperRenderers.Links;
using Rhythm.Drop.Web.TagHelperRenderers.Modals;

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
            .SetDefaultDropAttributesTagHelperRenderer()
            .SetDefaultDropComponentsTagHelperRenderer()
            .SetDefaultDropImageTagHelperRenderer()
            .SetDefaultDropLinkTagHelperRenderer()
            .SetDefaultDropModalsTagHelperRenderer()
            .SetDefaultDropPictureTagHelperRenderer()
            .SetDefaultDropPictureImageTagHelperRenderer();
    }

    /// <summary>
    /// Sets the default drop attributes tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropAttributesTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropAttributesTagHelperRenderer<DefaultDropAttributesTagHelperRenderer>();
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

    /// <summary>
    /// Sets the default drop modals tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropModalsTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropModalsTagHelperRenderer<DefaultDropModalsTagHelperRenderer>();
    }

    /// <summary>
    /// Sets the default drop picture tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropPictureTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropPictureTagHelperRenderer<DefaultDropPictureTagHelperRenderer>();
    }

    /// <summary>
    /// Sets the default drop picture image tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultDropPictureImageTagHelperRenderer(this IRhythmDropBuilder builder)
    {
        return builder.SetDropPictureImageTagHelperRenderer<DefaultDropPictureImageTagHelperRenderer>();
    }
}