namespace Rhythm.Drop.Models.Subcomponents;

using Rhythm.Drop.Models.Common;

/// <summary>
/// A contract all subcomponents must implement.
/// </summary>
/// <remarks>Subcomponents are a renderable item that belongs to a component. It should be self-contained but it is not standalone.</remarks>
public interface ISubcomponent : IHaveViewName
{
}