namespace Rhythm.Drop.Web.Infrastructure.Factories.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// The input required by <see cref="ISubcomponentMetaDataFactory"/>.
/// </summary>
/// <param name="Subcomponent">The subcomponent.</param>
/// <param name="Level">The level of the subcomponent.</param>
/// <param name="Index">The index of the subcomponent within the current collection of subcomponents.</param>
/// <param name="Total">The total number of subcomponents within the current collection of subcomponents.</param>
/// <param name="Theme">The theme of the subcomponent.</param>
/// <param name="Attributes">The attributes to be passed to the subcomponent.</param>
/// <param name="Section">The optional section of where this subcomponent is rendered.</param>
public sealed record SubcomponentMetaDataFactoryInput(ISubcomponent Subcomponent, int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section)
{
}