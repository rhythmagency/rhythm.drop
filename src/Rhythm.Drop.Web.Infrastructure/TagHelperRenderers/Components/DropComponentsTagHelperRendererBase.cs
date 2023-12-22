﻿namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Components;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering a collection of <see cref="IComponent"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropComponentsTagHelperRendererBase : IDropComponentsTagHelperRenderer
{
    /// <inheritdoc/>
    public async Task RenderAsync(DropComponentsTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNullOrEmpty(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderMultipleAsync(model, context, output);
    }

    /// <inheritdoc/>
    public async Task RenderAsync(DropComponentTagHelperRendererContext? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNull(model))
        {
            await RenderNullAsync(output);
            return;
        }

        await RenderSingleAsync(model, context, output);
    }

    /// <summary>
    /// Renders multiple components using a <see cref="DropComponentsTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderMultipleAsync(DropComponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Renders a single component using a <see cref="DropComponentTagHelperRendererContext"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderSingleAsync(DropComponentTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNullOrEmpty([NotNullWhen(false)] DropComponentsTagHelperRendererContext? model)
    {
        return model is null || model.Components.Count == 0;
    }

    /// <summary>
    /// Checks if the model is null.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    protected virtual bool IsNull([NotNullWhen(false)] DropComponentTagHelperRendererContext? model)
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