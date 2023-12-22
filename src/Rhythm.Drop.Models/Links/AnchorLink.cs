namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An implementation of <see cref="ILink"/> that is rendered as an anchor tag.
/// </summary>
/// <param name="Label">The label.</param>
/// <param name="Attributes">The attributes.</param>
public sealed record AnchorLink(string Label, IReadOnlyHtmlAttributeCollection Attributes) : ILink
{
    /// <inheritdoc/>
    public string TagName => "a";
}