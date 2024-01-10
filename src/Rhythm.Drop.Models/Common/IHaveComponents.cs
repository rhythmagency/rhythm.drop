namespace Rhythm.Drop.Models.Common;

using Rhythm.Drop.Models.Components;
using System.Collections.Generic;

/// <summary>
/// A contract for creating an component that has components within it.
/// </summary>
public interface IHaveComponents
{
    /// <summary>
    /// Gets the components within this object.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyCollection{T}"/> of <see cref="IComponent"/>.</returns>
    IReadOnlyCollection<IComponent> GetComponents();
}
