﻿namespace Rhythm.Drop.Infrastructure.Builders.Links.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;
using System.Collections.Generic;

/// <summary>
/// An implementation of <see cref="IContentAndLabelWithUniqueKeyLinkBuilder"/>.
/// </summary>
/// <param name="label">The label.</param>
/// <param name="content">The content.</param>
/// <param name="uniqueKey">The unique key.</param>
public sealed class ContentAndLabelWithUniqueKeyLinkBuilder(string? label, IReadOnlyCollection<IComponent> content, string uniqueKey) : IContentAndLabelWithUniqueKeyLinkBuilder
{
    /// <inheritdoc/>
    public string? Label => label;

    /// <inheritdoc/>
    public IReadOnlyCollection<IComponent> Content => content;

    /// <inheritdoc/>
    public string UniqueKey => uniqueKey;

    /// <summary>
    /// The attribute collection.
    /// </summary>
    private readonly IHtmlAttributeCollection _attributes = new HtmlAttributeCollection();

    /// <inheritdoc/>
    public IModalLink? Build()
    {
        if (string.IsNullOrWhiteSpace(Label))
        {
            return default;
        }

        if (Content.Count == 0)
        {
            return default;
        }

        var modal = new Modal(UniqueKey, Content);

        return new ButtonModalLink(modal, Label, _attributes.ToReadOnly());
    }
}