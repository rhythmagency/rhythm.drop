namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Options;

/// <summary>
/// The default implementation of <see cref="IViewPathHelper"/>.
/// </summary>
/// <param name="optionsMonitor">The options monitor.</param>
internal sealed class DefaultViewPathHelper(IOptionsMonitor<RenderingOptions> optionsMonitor) : ViewPathHelperBase(optionsMonitor)
{
}