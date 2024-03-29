﻿namespace Rhythm.Drop.Web.Helpers;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Helpers.Modals;
using Rhythm.Drop.Web.Helpers.Rendering;
using Rhythm.Drop.Web.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.Helpers;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to factories.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Registers web helper dependencies for the Rhythm Drop.
    /// </summary>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder AddWebHelpers(this IRhythmDropBuilder builder)
    {
        return builder
            .SetDefaultModalPersistenceHelper()
            .SetDefaultRenderingHelper()
            .SetDefaultThemeHelper()
            .SetDefaultViewPathHelper();
    }

    /// <summary>
    /// Sets the default modal persistence helper.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultModalPersistenceHelper(this IRhythmDropBuilder builder)
    {
        return builder.SetModalPersistenceHelper<DefaultModalPersistenceHelper>();
    }

    /// <summary>
    /// Sets the default rendering helper.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultRenderingHelper(this IRhythmDropBuilder builder)
    {
        return builder.SetRenderingHelper<DefaultRenderingHelper>();
    }

    /// <summary>
    /// Sets the default theme helper.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultThemeHelper(this IRhythmDropBuilder builder)
    {
        return builder.SetThemeHelper<DefaultThemeHelper>();
    }

    /// <summary>
    /// Sets the default view path helper.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultViewPathHelper(this IRhythmDropBuilder builder)
    {
        return builder.SetViewPathHelper<DefaultViewPathHelper>();
    }
}