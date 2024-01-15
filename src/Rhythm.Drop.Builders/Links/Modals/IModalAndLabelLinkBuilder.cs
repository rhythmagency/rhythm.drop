namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a link builder with modal and a label.
/// </summary>
public interface IModalAndLabelLinkBuilder : IHtmlAttributesLinkBuilder<IModalAndLabelLinkBuilder>, IHtmlClassesLinkBuilder<IModalAndLabelLinkBuilder>
{
    /// <summary>
    /// Gets the label of the link builder.
    /// </summary>
    string? Label { get; }

    /// <summary>
    /// Gets the modal of the link builder.
    /// </summary>
    IModal Modal { get; }

    /// <summary>
    /// Attempts to build a <see cref="IModalLink"/> based on the current input.
    /// </summary>
    /// <returns>A <see cref="IModalLink"/> if the input is valid.</returns>
    IModalLink? Build();
}