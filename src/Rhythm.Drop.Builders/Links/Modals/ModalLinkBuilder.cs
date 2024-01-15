namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An implementation of <see cref="IModalLinkBuilder"/>.
/// </summary>
/// <param name="modal">The modal.</param>
internal sealed class ModalLinkBuilder(IModal modal) : IModalLinkBuilder, IModalAndLabelLinkBuilder
{
    /// <summary>
    /// The internal attribute collection.
    /// </summary>
    private readonly HtmlAttributeCollection _attributes = new();

    /// <inheritdoc/>
    public IModal Modal => modal;

    /// <inheritdoc/>
    public string? Label { get; private set; }

    public IModalAndLabelLinkBuilder AddClass(string className)
    {
        _attributes.AddClass(className);
        return this;
    }

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder AndLabel(string? label)
    {
        Label = label;
        return this;
    }

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

        return new ModalLink(Modal, Label, _attributes.ToReadOnly());
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

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder RemoveClass(string className)
    {
        _attributes.RemoveClass(className);
        return this;
    }
}