namespace Rhythm.Drop.Web.Infrastructure.Helpers;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Infrastructure.Helpers.ViewPath;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to helpers.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Sets the modal persistence helper.
    /// </summary>
    /// <typeparam name="TModalPersistenceHelper">The type of the modal persistence helper.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetModalPersistenceHelper<TModalPersistenceHelper>(this IRhythmDropBuilder builder) where TModalPersistenceHelper : class, IModalPersistenceHelper
    {
        builder.Services.Replace<IModalPersistenceHelper, TModalPersistenceHelper>(ServiceLifetime.Scoped);

        return builder;
    }

    /// <summary>
    /// Sets the theme helper.
    /// </summary>
    /// <typeparam name="TThemeHelper">The type of the new theme helper.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetThemeHelper<TThemeHelper>(this IRhythmDropBuilder builder) where TThemeHelper : class, IThemeHelper
    {
        builder.Services.Replace<IThemeHelper, TThemeHelper>(ServiceLifetime.Singleton);

        return builder;
    }

    /// <summary>
    /// Sets the view path helper.
    /// </summary>
    /// <typeparam name="TViewPathHelper">The type of the new view path helper.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetViewPathHelper<TViewPathHelper>(this IRhythmDropBuilder builder) where TViewPathHelper : class, IViewPathHelper
    {
        builder.Services.Replace<IViewPathHelper, TViewPathHelper>(ServiceLifetime.Singleton);

        return builder;
    }
}