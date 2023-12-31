﻿namespace Rhythm.Drop.Infrastructure.Builders.Links.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An implementation of <see cref="IModalAndLabelLinkBuilder "/>.
/// </summary>
/// <param name="modal">The modal.</param>
/// <param name="label">The label.</param>
internal sealed class ModalAndLabelLinkBuilder(IModal modal, string? label) : IModalAndLabelLinkBuilder
{
    /// <summary>
    /// The HTML attributes.
    /// </summary>
    private readonly IHtmlAttributeCollection _attributes = new HtmlAttributeCollection();

    /// <inheritdoc/>
    public string? Label => label;

    /// <inheritdoc/>
    public IModal Modal => modal;

    /// <inheritdoc/>
    public IReadOnlyHtmlAttributeCollection Attributes => _attributes.ToReadOnly();

    /// <inheritdoc/>
    public IModalLink? Build()
    {
        if (string.IsNullOrWhiteSpace(Label))
        {
            return default;
        }

        if (Modal.Content.Count == 0)
        {
            return default;
        }

        return new ButtonModalLink(Modal, Label, _attributes.ToReadOnly());
    }

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder ExcludeAttribute(string name)
    {
        _attributes.RemoveAttribute(name);
        return this;
    }

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder IncludeAttribute(string name, object? value)
    {
        _attributes.SetAttribute(name, value);
        return this;
    }
}