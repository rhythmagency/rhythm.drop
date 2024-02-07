namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Attributes;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to tag helper renderers.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Sets the drop attributes tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropAttributesTagHelperRenderer">The type of the new drop attributes tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropAttributesTagHelperRenderer<TDropAttributesTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropAttributesTagHelperRenderer : class, IDropAttributesTagHelperRenderer
    {
        builder.Services.Replace<IDropAttributesTagHelperRenderer, TDropAttributesTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop components tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropComponentsTagHelperRenderer">The type of the new drop components tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropComponentsTagHelperRenderer<TDropComponentsTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropComponentsTagHelperRenderer : class, IDropComponentsTagHelperRenderer
    {
        builder.Services.Replace<IDropComponentsTagHelperRenderer, TDropComponentsTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop elements tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropElementsTagHelperRenderer">The type of the new drop elements tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropElementsTagHelperRenderer<TDropElementsTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropElementsTagHelperRenderer : class, IDropElementsTagHelperRenderer
    {
        builder.Services.Replace<IDropElementsTagHelperRenderer, TDropElementsTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop link tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropLinkTagHelperRenderer">The type of the new drop link tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropLinkTagHelperRenderer<TDropLinkTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropLinkTagHelperRenderer : class, IDropLinkTagHelperRenderer
    {
        builder.Services.Replace<IDropLinkTagHelperRenderer, TDropLinkTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop image tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropImageTagHelperRenderer">The type of the new drop image tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropImageTagHelperRenderer<TDropImageTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropImageTagHelperRenderer : class, IDropImageTagHelperRenderer
    {
        builder.Services.Replace<IDropImageTagHelperRenderer, TDropImageTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop modals tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropModalsTagHelperRenderer">The type of the new drop modals tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropModalsTagHelperRenderer<TDropModalsTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropModalsTagHelperRenderer : class, IDropModalsTagHelperRenderer
    {
        builder.Services.Replace<IDropModalsTagHelperRenderer, TDropModalsTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop picture tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropPictureTagHelperRenderer">The type of the new drop picture tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropPictureTagHelperRenderer<TDropPictureTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropPictureTagHelperRenderer : class, IDropPictureTagHelperRenderer
    {
        builder.Services.Replace<IDropPictureTagHelperRenderer, TDropPictureTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the drop picture image tag helper renderer.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <typeparam name="TDropPictureImageTagHelperRenderer">The type of the new drop picture image tag helper renderer.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDropPictureImageTagHelperRenderer<TDropPictureImageTagHelperRenderer>(this IRhythmDropBuilder builder) where TDropPictureImageTagHelperRenderer : class, IDropPictureImageTagHelperRenderer
    {
        builder.Services.Replace<IDropPictureImageTagHelperRenderer, TDropPictureImageTagHelperRenderer>(ServiceLifetime.Scoped);

        return builder;
    }
}