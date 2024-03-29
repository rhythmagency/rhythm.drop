﻿namespace Rhythm.Drop.Builders.Links;

/// <summary>
/// A contract for creating a link builder which modifies attributes.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after modifying HTML attributes.</typeparam>
public interface IHtmlAttributesLinkBuilder<TBuilder>
{
    /// <summary>
    /// Sets an attribute to the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder SetAttribute(string name, object? value);

    /// <summary>
    /// Removes an attribute from the current builder.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder RemoveAttribute(string name);
}