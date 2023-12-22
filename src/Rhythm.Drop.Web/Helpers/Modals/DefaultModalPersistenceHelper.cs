namespace Rhythm.Drop.Web.Helpers.Modals;

using Microsoft.AspNetCore.Http;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using System.Collections.Generic;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// The default implementation of <see cref="IModalPersistenceHelper"/>.
/// </summary>
/// <param name="httpContextAccessor">The HTTP context accessor.</param>
/// <remarks>This is a generic implementation and should be replaced by a specific implementation if used with other software like Umbraco CMS.</remarks>
internal sealed class DefaultModalPersistenceHelper(IHttpContextAccessor httpContextAccessor) : IModalPersistenceHelper
{
    /// <summary>
    /// The prefix to be added to
    /// </summary>
    private const string CacheKeyPrefix = "RhythmDrop__Modal__";

    /// <summary>
    /// The HTTP context accessor.
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    /// <inheritdoc/>
    public IReadOnlyCollection<IModal> GetAll()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Array.Empty<IModal>();
        }
     
        var modals = new List<IModal>();

        foreach (var item in _httpContextAccessor.HttpContext.Items)
        {
            if (IsItemKeyMatch(item.Key) is false)
            {
                continue;
            }

            if (item.Value is not IModal modal)
            {
                continue;
            }

            modals.Add(modal);
        }

        return modals.ToArray();
    }

    /// <inheritdoc/>
    public void Persist(IModal modal)
    {
        var cacheKey = $"{CacheKeyPrefix}_{modal.UniqueKey}";

        if (_httpContextAccessor.HttpContext is not null)
        {
            _httpContextAccessor.HttpContext.Items[cacheKey] = modal;
        }
    }

    private static bool IsItemKeyMatch(object key)
    {
        if (key is not string stringKey)
        {
            return false;
        }

        if (string.IsNullOrEmpty(stringKey))
        {
            return false;
        }

        return stringKey.StartsWith(CacheKeyPrefix) && stringKey.EndsWith(CacheKeyPrefix) is false;
    }
}