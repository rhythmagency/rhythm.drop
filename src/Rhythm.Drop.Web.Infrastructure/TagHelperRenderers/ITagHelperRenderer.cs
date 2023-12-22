namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

/// <summary>
/// A contract used for rendering a <typeparamref name="TModel"/> when used in a <see cref="TagHelper"/>.
/// </summary>
/// <typeparam name="TModel">The type of the model.</typeparam>
public interface ITagHelperRenderer<TModel>
{
    /// <summary>
    /// Render the <typeparamref name="TModel"/> asynchronously.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context of the current <see cref="TagHelper"/>.</param>
    /// <param name="output">The output of the current <see cref="TagHelper"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    Task RenderAsync(TModel? model, TagHelperContext context, TagHelperOutput output);
}