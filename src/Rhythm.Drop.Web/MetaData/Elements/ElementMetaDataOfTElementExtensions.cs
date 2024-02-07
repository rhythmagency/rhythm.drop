namespace Rhythm.Drop.Web.MetaData.Elements;

using Rhythm.Drop.Models.Common;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// A collection of extension methods that augment <see cref="ElementMetaData{TElement}"/>.
/// </summary>
public static class ElementMetaDataOfTypeExtensions
{
    /// <summary>
    /// Gets all the attributes from the meta data and the element.
    /// </summary>
    /// <typeparam name="TElement">The type of the element.</typeparam>
    /// <param name="metaData">The current element meta data.</param>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    public static IReadOnlyHtmlAttributeCollection AllAttributes<TElement>(this ElementMetaData<TElement> metaData) where TElement : class, IElement, IHaveAttributes
    {
        var collection = new HtmlAttributeCollection(metaData.Attributes);
        collection.SetAttributes(metaData.Attributes);

        return collection.ToReadOnly();
    }
}
