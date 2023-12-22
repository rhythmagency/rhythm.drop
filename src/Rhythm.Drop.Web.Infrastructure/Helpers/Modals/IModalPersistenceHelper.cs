namespace Rhythm.Drop.Web.Infrastructure.Helpers.Modals;

using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a helper which persists modals for a given request.
/// </summary>
public interface IModalPersistenceHelper
{
    /// <summary>
    /// Persist a modal for later use.
    /// </summary>
    /// <param name="modal">The modal to persist.</param>
    void Persist(IModal modal);

    /// <summary>
    /// Gets any persisted modals.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyCollection{T}"/> of <see cref="IModal"/> objects.</returns>
    IReadOnlyCollection<IModal> GetAll();
}