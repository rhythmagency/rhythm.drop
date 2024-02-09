namespace Rhythm.Drop.Web.Infrastructure.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// An abstract non-generic type for Subcomponent Meta Data.
/// </summary>
/// <param name="Index">The index of the subcomponent within the current collection of subcomponents.</param>
/// <param name="Total">The total number of subcomponents within the current collection of subcomponents.</param>
/// <param name="Theme">The theme of the subcomponent.</param>
/// <param name="Attributes">The additional HTML attributes.</param>
/// <param name="Section">The optional section of where this subcomponent is rendered.</param>
/// <remarks>
/// <para>
/// This type exists to make it easier to construct and return a generic Subcomponent Meta Data.
/// </para>
/// <para>
/// It should not be used to create other types.
/// </para>
/// </remarks>
public abstract record SubcomponentMetaData(int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : CollectionMetaData(Index, Total, Theme)
{
    /// <summary>
    /// Gets the subcomponent of the meta data.
    /// </summary>
    /// <returns>A <see cref="ISubcomponent"/>.</returns>
    public abstract ISubcomponent GetSubcomponent();
}