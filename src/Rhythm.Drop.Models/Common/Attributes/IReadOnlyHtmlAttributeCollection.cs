namespace Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A contract for implementing a read only <see cref="IHtmlAttributeCollectionBase"/>.
/// </summary>
public interface IReadOnlyHtmlAttributeCollection : IHtmlAttributeCollectionBase
{
    /// <summary>
    /// Converts the current collection to an editable collection.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    IHtmlAttributeCollection ToEditable();
}