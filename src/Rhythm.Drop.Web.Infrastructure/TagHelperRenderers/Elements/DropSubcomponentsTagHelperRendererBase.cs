namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Subcomponents;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering a collection of <see cref="ISubcomponent"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropSubcomponentsTagHelperRendererBase : IDropSubcomponentsTagHelperRenderer
{
    /// <inheritdoc/>
    public async Task RenderAsync(DropSubcomponentsTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNullOrEmpty(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderMultipleAsync(model, context, output);
    }

    /// <inheritdoc/>
    public async Task RenderAsync(DropSubcomponentTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNull(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderSingleAsync(model, context, output);
    }

    /// <summary>
    /// Renders multiple subcomponents using a <see cref="DropSubcomponentsTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderMultipleAsync(DropSubcomponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Renders a single subcomponent using a <see cref="DropSubcomponentTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderSingleAsync(DropSubcomponentTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNullOrEmpty([NotNullWhen(false)] DropSubcomponentsTagHelperRendererContext? model)
    {
        return model is null || model.Subcomponents.Count == 0;
    }

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNull([NotNullWhen(false)] DropSubcomponentTagHelperRendererContext? model)
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