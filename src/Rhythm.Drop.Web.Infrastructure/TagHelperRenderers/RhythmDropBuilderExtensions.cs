﻿namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to tag helper renderers.
/// </summary>
public static class RhythmDropBuilderExtensions
{
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
}