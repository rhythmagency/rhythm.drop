namespace Rhythm.Drop.Builders.Links.Url;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/> with a URL.
/// </summary>
public interface IUrlLinkBuilder
{
    /// <summary>
    /// Gets the URL of the link builder.
    /// </summary>
    string? Url { get; }

    /// <summary>
    /// Adds a label to the builder.
    /// </summary>
    /// <param name="label">The label.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder AndLabel(string? label);
}