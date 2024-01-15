namespace Rhythm.Drop.Builders.Links;

/// <summary>
/// A contract for creating a link builder which modifies HTML classes.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after modifying HTML classes.</typeparam>
public interface IHtmlClassesLinkBuilder<TBuilder>
{
    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to add.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AddClass(string className);

    /// <summary>
    /// Adds a class to the current builder.
    /// </summary>
    /// <param name="className">The class name to remove.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder RemoveClass(string className);
}