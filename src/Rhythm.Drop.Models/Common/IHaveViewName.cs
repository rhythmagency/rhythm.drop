namespace Rhythm.Drop.Models.Common;

/// <summary>
/// A contract which states this type will have a view name.
/// </summary>
public interface IHaveViewName
{
    /// <summary>
    /// Gets the view name.
    /// </summary>
    string ViewName { get; }
}