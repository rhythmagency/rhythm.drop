﻿namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// A base <see cref="ITagHelperRenderer{TModel}" /> to assist with common functionality.
/// </summary>
/// <typeparam name="TModel">The type of the model.</typeparam>
public abstract class TagHelperRendererBase<TModel> : ITagHelperRenderer<TModel>
{
    /// <summary>
    /// Renders the model asynchronously.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context of the current <see cref="TagHelper"/>.</param>
    /// <param name="output">The output of the current <see cref="TagHelper"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    /// <remarks>This method will render the model depending on whether it is null or not.</remarks>
    public async Task RenderAsync(TModel? model, TagHelperContext context, TagHelperOutput output)
    {
        if (IsNull(model))
        {
            await RenderNullAsync(context, output);
        }
        else
        {
            await RenderModelAsync(model, context, output);
        }
    }

    /// <summary>
    /// Renders the <typeparamref name="TModel"/> asynchronously.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context of the current <see cref="TagHelper"/>.</param>
    /// <param name="output">The output of the current <see cref="TagHelper"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    /// <remarks>The model is never null in this scenario.</remarks>
    protected abstract Task RenderModelAsync(TModel model, TagHelperContext context, TagHelperOutput output);

    /// <summary>
    /// How the <typeparamref name="TModel"/> should be rendered if it is <see langword="null"/>.
    /// </summary>
    /// <param name="context">The context of the current <see cref="TagHelper"/>.</param>
    /// <param name="output">The output of the current <see cref="TagHelper"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected abstract Task RenderNullAsync(TagHelperContext context, TagHelperOutput output);

    protected virtual bool IsNull([NotNullWhen(false)] TModel? model)
    {
        return model is null;
    }
}