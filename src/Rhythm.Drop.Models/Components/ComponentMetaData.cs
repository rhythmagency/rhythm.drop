namespace Rhythm.Drop.Models.Components;

using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// An abstract non-generic type for Component Meta Data.
/// </summary>
/// <param name="Level">The level of the component.</param>
/// <param name="Index">The index of the component within the current collection of components.</param>
/// <param name="Total">The total number of components within the current collection of components.</param>
/// <remarks>
/// <para>
/// This type exists to make it easier to construct and return a generic Component Meta Data.
/// </para>
/// <para>
/// It should not be used to create other types.
/// </para>
/// </remarks>
public abstract record ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes)
{
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
}