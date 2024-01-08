namespace Rhythm.Drop.Infrastructure.Builders.Links.Url;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;

/// <summary>
/// An implementation of <see cref="IUrlAndLabelLinkBuilder"/>.
/// </summary>
/// <param name="url">The URL.</param>
/// <param name="label">The label.</param>
internal sealed class UrlAndLabelLinkBuilder(string? url, string? label) : IUrlAndLabelLinkBuilder
{
    /// <inheritdoc/>
    public string? Url => url;

    /// <inheritdoc/>
    public string? Label => label;

    /// <inheritdoc/>
    public IReadOnlyHtmlAttributeCollection Attributes => _attributes.ToReadOnly();

    /// <summary>
    /// The attributes.
    /// </summary>
    private readonly IHtmlAttributeCollection _attributes = new HtmlAttributeCollection();

    /// <inheritdoc/>
    public ILink? Build()
    {
        if (string.IsNullOrWhiteSpace(Label) || string.IsNullOrWhiteSpace(Url))
        {
            return default;
        }

        _attributes.SetAttribute("href", Url);

        return new AnchorLink(Label, Attributes);
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder ExcludeAttribute(string name)
    {
        _attributes.RemoveAttribute(name);
        return this;
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder IncludeAttribute(string name, object? value)
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