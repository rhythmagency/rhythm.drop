using Rhythm.Drop.Models.Common.Attributes;

namespace Rhythm.Drop.Models.Links;

/// <summary>
/// A contract for creating a link.
/// </summary>
public interface ILink
{
    /// <summary>
    /// Gets the tag name to be used during rendering.
    /// </summary>
    string TagName { get; }

    /// <summary>
    /// Gets the label to be used during rendering.
    /// </summary>
    string Label { get; }

    /// <summary>
    /// Gets the attributes to be used during rendering.
    /// </summary>
    IReadOnlyHtmlAttributeCollection Attributes { get; }
}