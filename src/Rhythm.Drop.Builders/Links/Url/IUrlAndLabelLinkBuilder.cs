namespace Rhythm.Drop.Builders.Links.Url;

using Rhythm.Drop.Builders.Links;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/> with a URL and label.
/// </summary>
public interface IUrlAndLabelLinkBuilder : IHtmlAttributesLinkBuilder<IUrlAndLabelLinkBuilder>, IHtmlClassesLinkBuilder<IUrlAndLabelLinkBuilder>
{
    /// <summary>
    /// Gets the URL of the link builder.
    /// </summary>
    string? Url { get; }

    /// <summary>
    /// Gets the label of the link builder.
    /// </summary>
    string? Label { get; }

    /// <summary>
    /// Attempts to build a <see cref="ILink"/> with a URL and label.
    /// </summary>
    /// <returns>A <see cref="ILink"/> if the input is valid.</returns>
    ILink? Build();
}