namespace Rhythm.Drop.Builders.Links.Url;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;

/// <summary>
/// An implementation of <see cref="IUrlLinkBuilder"/>.
/// </summary>
/// <param name="url">The URL.</param>
internal sealed class UrlLinkBuilder(string? url) : IUrlLinkBuilder, IUrlAndLabelLinkBuilder
{
    /// <summary>
    /// The internal attributes.
    /// </summary>
    private readonly HtmlAttributeCollection _attributes = new();

    /// <inheritdoc/>
    public string? Url => url;

    /// <inheritdoc/>
    public string? Label { get; private set; }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder AndLabel(string? label)
    {
        Label = label;
        return this;
    }

    /// <inheritdoc/>
    public ILink? Build()
    {
        if (string.IsNullOrWhiteSpace(Label) || string.IsNullOrWhiteSpace(Url))
        {
            return default;
        }

        _attributes.SetAttribute("href", Url);

        return new AnchorLink(Label, _attributes.ToReadOnly());
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder RemoveAttribute(string name)
    {
        _attributes.RemoveAttribute(name);
        return this;
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder SetAttribute(string name, object? value)
    {
        _attributes.SetAttribute(name, value);
        return this;
    }


    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder AddClass(string className)
    {
        _attributes.AddClass(className);
        return this;
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder RemoveClass(string className)
    {
        _attributes.RemoveClass(className);
        return this;
    }
}