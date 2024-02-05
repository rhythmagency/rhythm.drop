namespace Rhythm.Drop.Models.Modals;

using Rhythm.Drop.Models.Common;
using Rhythm.Drop.Models.Components;
using System.Collections.Generic;

/// <summary>
/// A contract for creating a modal.
/// </summary>
public interface IModal : IHaveAttributes, IHaveComponents, IHaveViewName
{
    /// <summary>
    /// Gets the unique key of modal.
    /// </summary>
    string UniqueKey { get; }

    /// <summary>
    /// Gets the content of the modal.
    /// </summary>
    IReadOnlyCollection<IComponent> Content { get; }
}