namespace Rhythm.Drop.Web.Infrastructure.Helpers.Modals;

using Rhythm.Drop.Models.Links;

/// <summary>
/// A collection of extension methods which augment <see cref="IModalPersistenceHelper"/> implementations.
/// </summary>
public static class ModalPersistenceHelperExtensions
{
    /// <summary>
    /// Persist the modal content of a link for later use.
    /// </summary>
    /// <param name="helper">The helper.</param>
    /// <param name="link">The link to persist.</param>
    public static void Persist(this IModalPersistenceHelper helper, IModalLink link)
    {
        helper.Persist(link.Modal);
    }
}