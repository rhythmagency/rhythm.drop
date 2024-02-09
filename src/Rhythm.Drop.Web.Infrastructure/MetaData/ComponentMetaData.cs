namespace Rhythm.Drop.Web.Infrastructure.MetaData;

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
public abstract record ComponentMetaData(int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : ComponentMetaDataBase(Level, Index, Total, Theme, Attributes, Section)
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
}