namespace Rhythm.Drop.Web.MetaData.Components;

using Rhythm.Drop.Web.Infrastructure.MetaData.Components;

/// <summary>
/// A collection of extension methods that augment the Component Meta Data.
/// </summary>
public static class ComponentMetaDataExtensions
{
    /// <summary>
    /// The modulus for an even indexed item.
    /// </summary>
    private const int EvenIndexedItemModulus = 0;

    /// <summary>
    /// Gets a non-zero version of the current <see cref="ComponentMetaData.Index"/>.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="int"/>.</returns>
    public static int HumanReadableIndex(this ComponentMetaData metaData)
    {
        return metaData.Index + 1;
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData"/> is first or not.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta is first.</returns>
    public static bool IsFirst(this ComponentMetaData metaData)
    {
        return metaData.Index is ComponentMetaData.FirstItemIndex;
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData"/> is last or not.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta is last.</returns>
    public static bool IsLast(this ComponentMetaData metaData)
    {
        return metaData.HumanReadableIndex().Equals(metaData.Total);
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData.Index"/> is an odd number.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta's index is an odd number.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex(ComponentMetaData)"/> value not <see cref="Index"/>.</remarks>
    public static bool IsEven(this ComponentMetaData metaData)
    {
        return metaData.CalculateOddOrEvenModulus() is EvenIndexedItemModulus;
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData.Index"/> is an even number.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta's index is an even number.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex(ComponentMetaData)"/> value not <see cref="Index"/>.</remarks>
    public static bool IsOdd(this ComponentMetaData metaData)
    {
        return metaData.CalculateOddOrEvenModulus() is not EvenIndexedItemModulus;
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData"/> is at root level or not.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta is at root level.</returns>
    public static bool IsRootLevel(this ComponentMetaData metaData)
    {
        return metaData.Level is ComponentMetaData.RootLevel;
    }

    /// <summary>
    /// Checks if the current <see cref="ComponentMetaData"/> is the only one in the collection.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="bool"/> which represents if this component meta is the only one in the collection.</returns>
    public static bool IsTheOnlyOne(this ComponentMetaData metaData)
    {
        return metaData.Total is 1;
    }

    /// <summary>
    /// Gets the level below the current <see cref="ComponentMetaData.Level"/>.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="int"/>.</returns>
    public static int NextLevel(this ComponentMetaData metaData)
    {
        return metaData.Level + 1;
    }

    /// <summary>
    /// Gets the level above the current <see cref="ComponentMetaData.Level"/>.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="int"/>.</returns>
    /// <remarks>This will never be lower than <see cref="ComponentMetaData.RootLevel"/>.</remarks>
    public static int PreviousLevel(this ComponentMetaData metaData)
    {
        return metaData.IsRootLevel() ? ComponentMetaData.RootLevel : metaData.Level - 1;
    }

    /// <summary>
    /// Internal function to sharing calculating the modulus for <see cref="IsEven(ComponentMetaData)"/> and <see cref="IsOdd(ComponentMetaData)"/>.
    /// </summary>
    /// <param name="metaData">The current component meta data.</param>
    /// <returns>A <see cref="int"/> which represents the modulus.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex(ComponentMetaData)"/> value not <see cref="Index"/>.</remarks>
    private static int CalculateOddOrEvenModulus(this ComponentMetaData metaData)
    {
        return metaData.HumanReadableIndex() % 2;
    }
}