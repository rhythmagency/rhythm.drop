namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An implementation of <see cref="IHtmlAttribute"/>.
/// </summary>
/// <param name="Name">The name.</param>
/// <param name="Value">The value.</param>
public sealed record HtmlAttribute(string Name, object? Value) : IHtmlAttribute
{
}