namespace Rhythm.Drop.Models.Common.Attributes;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// A base contract for creating a collection of <see cref="IHtmlAttribute"/> objects.
/// </summary>
public interface IHtmlAttributeCollectionBase : IReadOnlyCollection<IHtmlAttribute>
{
    /// <summary>
    /// Checks if the collection has an attribute by a given name.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <returns>A <see cref="bool"/> which represents if the collection does contain an attribute by that name.</returns>
    bool HasAttribute(string name);

    /// <summary>
    /// Attempts to get a value of an attribute by name.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The output value.</param>
    /// <returns>A <see cref="bool"/> which represents if the attempt was successful.</returns>
    bool TryGetValue<TValue>(string name, [NotNullWhen(true)] out TValue? value);
}