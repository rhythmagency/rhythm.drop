namespace Rhythm.Drop.Builders.Links;

using Rhythm.Drop.Builders.Links.Modals;
using Rhythm.Drop.Builders.Links.Url;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a fluent builder used to create <see cref="ILink"/>
/// </summary>
public interface ILinkBuilder
{
    /// <summary>
    /// Adds a URL to the builder.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>A <see cref="IUrlLinkBuilder"/>.</returns>
    IUrlLinkBuilder WithUrl(string? url);

    /// <summary>
    /// Adds a URL to the builder.
    /// </summary>
    /// <param name="modal">The modal.</param>
    /// <returns>A <see cref="IModalLinkBuilder"/>.</returns>
    IModalLinkBuilder WithModal(IModal? modal);
}