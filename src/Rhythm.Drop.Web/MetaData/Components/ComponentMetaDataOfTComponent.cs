
namespace Rhythm.Drop.Web.MetaData.Components;

using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure.MetaData.Components;

/// <summary>
/// A generic type for Component Meta Data.
/// </summary>
/// <typeparam name="TComponent">The type of the component.</typeparam>
/// <param name="Component">The component.</param>
/// <param name="Level">The level of the component.</param>
/// <param name="Index">The index of the component within the current collection of components.</param>
/// <param name="Total">The total number of components within the current collection of components.</param>
/// <param name="Theme">The theme of the component.</param>
/// <param name="Attributes">The attributes to be passed to the component.</param>
/// <param name="Section">The optional section of where this component is rendered.</param>
public sealed record ComponentMetaData<TComponent>(TComponent Component, int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : ComponentMetaData(Level, Index, Total, Theme, Attributes, Section) where TComponent : IComponent
{
    /// <summary>
    /// A generic type for Component Meta Data
    /// </summary>
    /// <remarks>This creates a component meta data without a section for backward compatability.</remarks>
    public ComponentMetaData(TComponent Component, int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Component, Level, Index, Total, Theme, Attributes, default)
    {
    }

    /// <inheritdoc/>
    public override string ViewName => Component.ViewName;    
}