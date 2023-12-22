namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A contract for creating an attribute.
/// </summary>
public interface IHtmlAttribute
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    object? Value { get; }
}