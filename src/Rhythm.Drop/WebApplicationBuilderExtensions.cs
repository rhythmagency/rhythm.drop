namespace Rhythm.Drop;

using Microsoft.AspNetCore.Builder;
using Rhythm.Drop.Infrastructure;

/// <summary>
/// A collection of extension methods that augment implementations of <see cref="WebApplicationBuilder"/> regarding Rhythm Drop.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Adds Rhythm Drop with default dependencies to the current <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The current web application builder.</param>
    /// <returns>A <see cref="WebApplicationBuilder"/>.</returns>
    /// <remarks>For a more controlled installation use <see cref="AddRhythmDrop(WebApplicationBuilder, Action{IRhythmDropBuilder})"/>.</remarks>
    public static WebApplicationBuilder AddRhythmDrop(this WebApplicationBuilder builder)
    {
        builder.Services.AddRhythmDrop();

        return builder;
    }

    /// <summary>
    /// Adds Rhythm Drop with configured dependencies to the current <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The current web application builder.</param>
    /// <param name="configure">The configuration action.</param>
    /// <returns>A <see cref="WebApplicationBuilder"/>.</returns>
    /// <remarks>Developer must add any dependencies (e.g. Infrastructure and Web) here.</remarks>
    public static WebApplicationBuilder AddRhythmDrop(this WebApplicationBuilder builder, Action<IRhythmDropBuilder> configure)
    {
        builder.Services.AddRhythmDrop(configure);

        return builder;
    }
}
