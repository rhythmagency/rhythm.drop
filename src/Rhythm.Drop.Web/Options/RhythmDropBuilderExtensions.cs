namespace Rhythm.Drop.Web.Options;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;

/// <summary>
/// A collection of extension methods that augment the <see cref="IRhythmDropBuilder"/> related to configuration.
/// </summary>
internal static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Add options to the <see cref="IRhythmDropBuilder"/>.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <returns>The <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddWebOptions(this IRhythmDropBuilder builder)
    {
        return builder.AddComponentsOptions();
    }

    /// <summary>
    /// Adds the <see cref="RenderingOptions"/> to the <see cref="IRhythmDropBuilder"/>.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <returns>The <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddComponentsOptions(this IRhythmDropBuilder builder)
    {
        builder.Services
            .AddOptions<RenderingOptions>()
            .BindConfiguration(RenderingOptions.SectionName);

        return builder;
    }
}