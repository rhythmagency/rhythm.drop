namespace Rhythm.Drop.Web.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;
using Rhythm.Drop.Web.Infrastructure.MetaData;

/// <summary>
/// A generic type for Subcomponent Meta Data.
/// </summary>
/// <typeparam name="TSubcomponent">The type of the subcomponent.</typeparam>
/// <param name="Subcomponent">The subcomponent.</param>
/// <param name="Index">The index of the subcomponent within the current collection of subcomponents.</param>
/// <param name="Total">The total number of subcomponents within the current collection of subcomponents.</param>
/// <param name="Theme">The theme of the subcomponent.</param>
/// <param name="Attributes">The attributes to be passed to the subcomponent.</param>
/// <param name="Section">The optional section of where this subcomponent is rendered.</param>
public sealed record SubcomponentMetaData<TSubcomponent>(TSubcomponent Subcomponent, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : SubcomponentMetaData(Index, Total, Theme, Attributes, Section) where TSubcomponent : ISubcomponent
{
    /// <inheritdoc/>
    public override ISubcomponent GetSubcomponent()
    {
        return Subcomponent;
    }
}