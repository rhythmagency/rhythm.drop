namespace Rhythm.Drop.Web.Infrastructure.MetaData.Components;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;

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
public abstract record ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : CollectionMetaData(Index, Total, Theme)
{
    /// <summary>
    /// An abstract non-generic type for Component Meta Data.
    /// </summary>
    /// <remarks>This creates a component meta data without a section for backward compatability.</remarks>
    public ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Level, Index, Total, Theme, Attributes, default)
    {
    }

    /// <summary>
    /// Gets the component of the meta data.
    /// </summary>
    /// <returns>A <see cref="IComponent"/>.</returns>
    public abstract IComponent GetComponent();

    /// <summary>
    /// The absolute lowest level a component can be.
    /// </summary>
    public const int RootLevel = 0;

    /// <summary>
    /// Checks if this meta data is at root level or not.
    /// </summary>
    /// <returns>A <see cref="bool"/> which represents if this component meta is at root level.</returns>
    public bool IsRootLevel()
    {
        return Level is RootLevel;
    }

    /// <summary>
    /// Gets the level above the current <see cref="Level"/>.
    /// </summary>
    /// <returns>A <see cref="int"/>.</returns>
    public int NextLevel()
    {
        return Level + 1;
    }

    /// <summary>
    /// Gets the level above the current <see cref="ComponentMetaData.Level"/>.
    /// </summary>
    /// <returns>A <see cref="int"/>.</returns>
    /// <remarks>This will never be lower than <see cref=".RootLevel"/>.</remarks>
    public int PreviousLevel()
    {
        return IsRootLevel() ? RootLevel : Level - 1;
    }


}