namespace Rhythm.Drop.Builders.Links.Url;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/> with a URL.
/// </summary>
public interface IUrlLinkBuilder : IAndLabelLinkBuilder<IUrlAndLabelLinkBuilder>
{
    /// <summary>
    /// Gets the URL of the link builder.
    /// </summary>
    string? Url { get; }
}