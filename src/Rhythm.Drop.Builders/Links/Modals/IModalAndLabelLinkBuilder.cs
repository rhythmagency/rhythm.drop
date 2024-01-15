namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Infrastructure.Builders.Links.Url;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a link builder with modal and a label.
/// </summary>
public interface IModalAndLabelLinkBuilder
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
    /// Adds an attribute to the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder IncludeAttribute(string name, object? value);

    /// <summary>
    /// Removes an attribute from the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder ExcludeAttribute(string name);


    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to add.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder AddClass(string className);

    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to remove.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder RemoveClass(string className);

    /// <summary>
    /// Attempts to build a <see cref="IModalLink"/> based on the current input.
    /// </summary>
    /// <returns>A <see cref="IModalLink"/> if the input is valid.</returns>
    IModalLink? Build();
}