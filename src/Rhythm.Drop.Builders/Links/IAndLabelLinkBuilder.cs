namespace Rhythm.Drop.Builders.Links;

/// <summary>
/// A contract for creating a link builder which adds a label.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after adding a label.</typeparam>
public interface IAndLabelLinkBuilder<TBuilder>
{
    /// <summary>
    /// Adds a label to the builder.
    /// </summary>
    /// <param name="label">The label.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AndLabel(string? label);
}