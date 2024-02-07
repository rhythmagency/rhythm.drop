namespace Rhythm.Drop.Web.Infrastructure.MetaData;

/// <summary>
/// An abstract object for creating meta data which exists within a collection of other meta data.
/// </summary>
/// <param name="Index">The zero-based index of the element within the current collection.</param>
/// <param name="Total">The total number of elements within the current collection.</param>
/// <param name="Theme">The theme of the meta data.</param>
public abstract record CollectionMetaData(int Index, int Total, string Theme) : MetaData(Theme)
{
    private readonly int _humanReadableIndex = Index + 1;

    /// <summary>
    /// The first item index.
    /// </summary>
    public const int FirstItemIndex = 0;

    /// <summary>
    /// The modulus for an even indexed item.
    /// </summary>
    private const int EvenIndexedItemModulus = 0;

    /// <summary>
    /// Gets a non-zero based version of the current <see cref="Index"/>.
    /// </summary>
    /// <returns>A <see cref="int"/>.</returns>
    public int HumanReadableIndex => _humanReadableIndex;

    /// <summary>
    /// Checks if the current <see cref="CollectionMetaData"/> is first or not.
    /// </summary>
    /// <returns>A <see cref="bool"/> which represents if this meta data is first.</returns>
    public bool IsFirst()
    {
        return Index is FirstItemIndex;
    }

    /// <summary>
    /// Checks if the current <see cref="CollectionMetaData"/> is last or not.
    /// </summary>

    /// <returns>A <see cref="bool"/> which represents if this meta data is last.</returns>
    public bool IsLast()
    {
        return HumanReadableIndex.Equals(Total);
    }

    /// <summary>
    /// Checks if the current index is an odd number.
    /// </summary>

    /// <returns>A <see cref="bool"/> which represents if this meta data's index is an odd number.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex"/> value not <see cref="Index"/>.</remarks>
    public bool IsEven()
    {
        return CalculateOddOrEvenModulus() is EvenIndexedItemModulus;
    }

    /// <summary>
    /// Checks if the current index is an even number.
    /// </summary>
    /// <returns>A <see cref="bool"/> which represents if this meta data's index is an even number.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex"/> value not the <see cref="Index"/>.</remarks>
    public bool IsOdd()
    {
        return CalculateOddOrEvenModulus() is not EvenIndexedItemModulus;
    }

    /// <summary>
    /// Checks if this meta data is the only one in the collection.
    /// </summary>
    /// <returns>A <see cref="bool"/> which represents if this meta data is the only one in the collection.</returns>
    public bool IsTheOnlyOne()
    {
        return Total is 1;
    }

    /// <summary>
    /// Internal function to sharing calculating the modulus for <see cref="IsEven()"/> and <see cref="IsOdd()"/>.
    /// </summary>
    /// <returns>A <see cref="int"/> which represents the modulus.</returns>
    /// <remarks>This is based on the <see cref="HumanReadableIndex"/> value not the <see cref="Index"/>.</remarks>
    private int CalculateOddOrEvenModulus()
    {
        return HumanReadableIndex % 2;
    }
}