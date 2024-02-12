namespace Rhythm.Drop.Web.Infrastructure.MetaData;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// An abstract object for creating meta data.
/// </summary>
public abstract record MetaData(string Theme, string? Section)
{
    /// <summary>
    /// Checks if the meta data has a value for <see cref="Section"/>.
    /// </summary>
    /// <returns>A <see cref="bool"/>.</returns>
    [MemberNotNullWhen(true, nameof(Section))]
    public virtual bool HasSection()
    {
        return string.IsNullOrEmpty(Section) is false;
    }

    /// <summary>
    /// Checks if the meta data has a specific value for <see cref="Section"/>.
    /// </summary>
    /// <returns>A <see cref="bool"/>.</returns>
    public virtual bool IsSection(string section)
    {
        return IsSection((x) => x.Equals(section));
    }

    /// <summary>
    /// Checks if the meta data has a specific value for <see cref="Section"/>.
    /// </summary>
    /// <returns>A <see cref="bool"/>.</returns>
    public virtual bool IsSection(string section, StringComparison comparisonType)
    {
        return IsSection((x) => x.Equals(section, comparisonType));
    }

    /// <summary>
    /// Checks if the meta data <see cref="Section"/> meets a specific criteria.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    /// <remarks><see cref="HasSection"/> will always be called before the <paramref name="predicate"/> is called.</remarks>
    public bool IsSection(Func<string, bool> predicate)
    {
        if (HasSection() is false)
        {
            return false;
        }

        return predicate(Section);
    }
}
