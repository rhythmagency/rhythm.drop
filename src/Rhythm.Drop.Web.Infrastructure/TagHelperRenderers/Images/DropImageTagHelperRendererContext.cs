namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;

/// <summary>
/// Context model for implementations of <see cref="IDropImageTagHelperRenderer"/>.
/// </summary>
/// <param name="Image">The image.</param>
/// <param name="LoadingMode">The loading mode.</param>
public sealed record DropImageTagHelperRendererContext(IImage? Image, LoadingMode LoadingMode)
{
}