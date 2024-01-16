namespace Rhythm.Drop.Web.Infrastructure.Factories.Components;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;

/// <summary>
/// The input required by <see cref="IComponentMetaDataFactory"/>.
/// </summary>
/// <param name="Component">The component.</param>
/// <param name="Level">The level of the component.</param>
/// <param name="Index">The index of the component within the current collection of components.</param>
/// <param name="Total">The total number of components within the current collection of components.</param>
/// <param name="Theme">The theme of the component.</param>
/// <param name="Attributes">The attributes to be passed to the component.</param>
/// <param name="Section">The optional section of where this component is rendered.</param>
public sealed record ComponentMetaDataFactoryInput(IComponent Component, int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, String? Section)
{
}