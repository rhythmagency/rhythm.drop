namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An implementation of <see cref="IReadOnlyHtmlAttributeCollection"/>.
/// </summary>
/// <remarks>
/// Constructs a <see cref="ReadOnlyHtmlAttributeCollection"/> from an existing collection.
/// </remarks>
/// <param name="attributes">The existing collection.</param>
public sealed class ReadOnlyHtmlAttributeCollection(IHtmlAttributeCollectionBase attributes) : HtmlAttributeCollectionBase(attributes), IReadOnlyHtmlAttributeCollection
{
    private static readonly Lazy<IReadOnlyHtmlAttributeCollection> _empty = new(() => new HtmlAttributeCollection().ToReadOnly());

    /// <summary>
    /// Gets an empty readonly collection.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/> which is empty.</returns>
    public static IReadOnlyHtmlAttributeCollection Empty() => _empty.Value;

    /// <inheritdoc/>
    public IHtmlAttributeCollection ToEditable()
    {
        return new HtmlAttributeCollection(this);
    }
}