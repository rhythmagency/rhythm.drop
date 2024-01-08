namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A contract for creating a <see cref="IHtmlAttributeCollectionBase"/> which can be modified.
/// </summary>
public interface IHtmlAttributeCollection : IHtmlAttributeCollectionBase
{
    /// <summary>
    /// Removes all attributes from this collection.
    /// </summary>
    void RemoveAll();

    /// <summary>
    /// Removes an attribute by name.
    /// </summary>
    /// <param name="name">The name of the attribute to be removed.</param>
    /// <returns>A <see cref="bool"/> which represents if the removal was successful.</returns>
    bool RemoveAttribute(string name);

    /// <summary>
    /// Sets an attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute</param>
    void SetAttribute(string name, object? value);

    /// <summary>
    /// Set multiple attributes from an existing collection.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    void SetAttributes(IHtmlAttributeCollectionBase attributes);

    /// <summary>
    /// Set multiple attributes from a generic collection (e.g. array, dictionary or list) of key value pairs.
    /// </summary>
    /// <param name="kvps">The attributes.</param>
    void SetAttributes(IReadOnlyCollection<KeyValuePair<string, object?>> kvps);

    /// <summary>
    /// Converts the current collection to read only.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    IReadOnlyHtmlAttributeCollection ToReadOnly();
}