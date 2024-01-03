namespace Rhythm.Drop.Models.Common;

using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A contract for creating a type with attributes.
/// </summary>
public interface IHaveAttributes
{
    /// <summary>
    /// Gets the HTML attributes.
    /// </summary>
    IReadOnlyHtmlAttributeCollection Attributes { get; }
}