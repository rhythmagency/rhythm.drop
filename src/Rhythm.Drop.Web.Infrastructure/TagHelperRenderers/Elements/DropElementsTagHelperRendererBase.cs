namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Elements;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering a collection of <see cref="IElement"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropElementsTagHelperRendererBase : IDropElementsTagHelperRenderer
{
    /// <inheritdoc/>
    public async Task RenderAsync(DropElementsTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNullOrEmpty(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderMultipleAsync(model, context, output);
    }

    /// <inheritdoc/>
    public async Task RenderAsync(DropElementTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNull(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderSingleAsync(model, context, output);
    }

    /// <summary>
    /// Renders multiple elements using a <see cref="DropElementsTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderMultipleAsync(DropElementsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Renders a single element using a <see cref="DropElementTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderSingleAsync(DropElementTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNullOrEmpty([NotNullWhen(false)] DropElementsTagHelperRendererContext? model)
    {
        return model is null || model.Elements.Count == 0;
    }

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNull([NotNullWhen(false)] DropElementTagHelperRendererContext? model)
    {
        return model is null;
    }

    /// <summary>
    /// Renders the output for a null scenario.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected virtual async Task RenderNullAsync(TagHelperOutput output)
    {
        await Task.Run(output.SuppressOutput);
    }
}