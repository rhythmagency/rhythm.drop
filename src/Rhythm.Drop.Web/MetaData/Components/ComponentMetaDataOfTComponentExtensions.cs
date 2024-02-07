namespace Rhythm.Drop.Web.MetaData.Components;

using Rhythm.Drop.Models.Common;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A collection of extension methods that augment <see cref="ComponentMetaData{TComponent}"/>.
/// </summary>
public static class ComponentMetaDataOfTypeExtensions
{
    /// <summary>
    /// Gets all the attributes from the meta data and the component.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    public static IReadOnlyHtmlAttributeCollection AllAttributes<TComponent>(this ComponentMetaData<TComponent> metaData) where TComponent : class, IComponent, IHaveAttributes
    {
        var collection = new HtmlAttributeCollection(metaData.Attributes);
        collection.SetAttributes(metaData.Attributes);

        return collection.ToReadOnly();
    }
}
