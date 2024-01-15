namespace Rhythm.Drop.Builders.Links.Url;

using Rhythm.Drop.Builders.Links;

using Rhythm.Drop.Infrastructure.Builders.Links;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/> with a URL and label.
/// </summary>
public interface IUrlAndLabelLinkBuilder
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
    /// Gets the attributes of the link builder.
    /// </summary>
    IReadOnlyHtmlAttributeCollection Attributes { get; }

    /// <summary>
    /// Attempts to build a <see cref="ILink"/> with a URL and label.
    /// </summary>
    /// <returns>A <see cref="ILink"/> if the input is valid.</returns>
    ILink? Build();

    /// <summary>
    /// Adds an attribute to the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder IncludeAttribute(string name, object? value);

    /// <summary>
    /// Removes an attribute from the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder ExcludeAttribute(string name);

    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to add.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder AddClass(string className);

    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to remove.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder RemoveClass(string className);
}