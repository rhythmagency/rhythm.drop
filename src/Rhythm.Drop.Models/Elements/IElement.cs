namespace Rhythm.Drop.Models.Elements;

using Rhythm.Drop.Models.Common;

/// <summary>
/// A contract all elements must implement.
/// </summary>
/// <remarks>Elements are a renderable item that belongs to a component. It should be self-contained but it is not standalone.</remarks>
public interface IElement : IHaveViewName
{
}