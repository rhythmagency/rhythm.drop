namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A contract for creating a link builder with content, a label and a unique key.
/// </summary>
public interface IContentAndLabelWithUniqueKeyLinkBuilder
{
    /// <summary>
    /// Gets the label of the builder.
    /// </summary>
    string? Label { get; }

    /// <summary>
    /// Gets the content of the builder.
    /// </summary>
    IReadOnlyCollection<IComponent> Content { get; }

    /// <summary>
    /// Gets the label of the builder.
    /// </summary>
    string UniqueKey { get; }

    /// <summary>
    /// Attempts to build a <see cref="IModalLink"/> based on the current input.
    /// </summary>
    /// <returns>A <see cref="IModalLink"/> if the input is valid.</returns>
    IModalLink? Build();
}