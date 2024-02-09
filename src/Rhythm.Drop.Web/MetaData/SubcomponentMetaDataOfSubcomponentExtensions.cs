namespace Rhythm.Drop.Web.MetaData;

using Rhythm.Drop.Models.Common;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// A collection of extension methods that augment <see cref="SubcomponentMetaData{TSubcomponent}"/>.
/// </summary>
public static class SubcomponentMetaDataOfTypeExtensions
{
    /// <summary>
    /// Gets all the attributes from the meta data and the subcomponent.
    /// </summary>
    /// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
    /// <param name="metaData">The current subcomponent meta data.</param>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    public static IReadOnlyHtmlAttributeCollection AllAttributes<TSubcomponent>(this SubcomponentMetaData<TSubcomponent> metaData) where TSubcomponent : class, ISubcomponent, IHaveAttributes
    {
        var collection = new HtmlAttributeCollection(metaData.Attributes);
        collection.SetAttributes(metaData.Attributes);

        return collection.ToReadOnly();
    }
}
