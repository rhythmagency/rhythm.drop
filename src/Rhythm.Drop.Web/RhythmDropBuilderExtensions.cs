namespace Rhythm.Drop.Web;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Factories;
using Rhythm.Drop.Web.Helpers;
using Rhythm.Drop.Web.Options;
using Rhythm.Drop.Web.TagHelperRenderers;

/// <summary>
/// A collection of methods that augment <see cref="IRhythmDropBuilder"/> with regards to web functionality..
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Adds configuration and default implementations required by web functionality.
    /// </summary>
    /// <param name="builder">The Rhythm Drop builder.</param>
    /// <returns>A <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddWeb(this IRhythmDropBuilder builder)
    {
        return builder
            .AddFactories()
            .AddHelpers()
            .AddOptions()
            .AddTagHelperRenderers();
    }
}