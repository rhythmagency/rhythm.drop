namespace Rhythm.Drop.Web.Infrastructure.MetaData.Components;

using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An abstract non-generic type for Component Meta Data.
/// </summary>
/// <param name="Level">The level of the component.</param>
/// <param name="Index">The index of the component within the current collection of components.</param>
/// <param name="Total">The total number of components within the current collection of components.</param>
/// <param name="Theme">The theme of the component.</param>
/// <param name="Attributes">The additional HTML attributes.</param>
/// <param name="Section">The optional section of where this component is rendered.</param>
/// <remarks>
/// <para>
/// This type exists to make it easier to construct and return a generic Component Meta Data.
/// </para>
/// <para>
/// It should not be used to create other types.
/// </para>
/// </remarks>
public abstract record ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section)
{
    /// <summary>
    /// An abstract non-generic type for Component Meta Data.
    /// </summary>
    /// <remarks>This creates a component meta data without a section for backward compatability.</remarks>
    public ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Level, Index, Total, Theme, Attributes, default)
    {
    }

    /// <summary>
    /// The absolute lowest level a component can be.
    /// </summary>
    public const int RootLevel = 0;

    /// <summary>
    /// The first item index.
    /// </summary>
    public const int FirstItemIndex = 0;

    /// <summary>
    /// The modulus for an even indexed item.
    /// </summary>
    internal const int EvenIndexedItemModulus = 0;

    /// <summary>
    /// Gets the view name for the component meta data.
    /// </summary>
    /// <returns>A <see cref="string"/>.</returns>
    public abstract string ViewName();
}