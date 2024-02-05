namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Modals;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering a collection of <see cref="IModal"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropModalsTagHelperRendererBase : IDropModalsTagHelperRenderer
{
    /// <inheritdoc/>
    public async Task RenderAsync(DropModalsTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNullOrEmpty(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderMultipleAsync(model, context, output);
    }

    /// <inheritdoc/>
    public async Task RenderAsync(DropModalTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNull(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderSingleAsync(model, context, output);
    }

    /// <summary>
    /// Renders multiple modals using a <see cref="DropModalsTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderMultipleAsync(DropModalsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Renders a single modal using a <see cref="DropModalTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderSingleAsync(DropModalTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNullOrEmpty([NotNullWhen(false)] DropModalsTagHelperRendererContext? model)
    {
        return model is null || model.Modals.Count == 0;
    }

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNull([NotNullWhen(false)] DropModalTagHelperRendererContext? model)
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