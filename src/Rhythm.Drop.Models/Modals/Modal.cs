namespace Rhythm.Drop.Models.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;
using System.Collections.Generic;

/// <summary>
/// An implementation of <see cref="IModal"/>.
/// </summary>
/// <param name="UniqueKey">The unique key.</param>
/// <param name="Content">The content.</param>
/// <param name="Attributes">The attributes.</param>
public sealed record Modal(string UniqueKey, IReadOnlyCollection<IComponent> Content, IReadOnlyHtmlAttributeCollection Attributes) : IModal
{
    /// <summary>
    /// Constructs a <see cref="Modal"/> with no attributes.
    /// </summary>
    /// <param name="UniqueKey">The unique key.</param>
    /// <param name="Content">The content.</param>
    public Modal(string UniqueKey, IReadOnlyCollection<IComponent> Content) : this(UniqueKey, Content, ReadOnlyHtmlAttributeCollection.Empty())
    {
    }

    /// <summary>
    /// Constructs a <see cref="Modal"/> with attributes.
    /// </summary>
    /// <param name="UniqueKey">The unique key.</param>
    /// <param name="Content">The content.</param>
    /// <param name="Attributes">The attributes.</param>
    public Modal(string UniqueKey, IReadOnlyCollection<IComponent> Content, IHtmlAttributeCollection Attributes) : this(UniqueKey, Content, Attributes.ToReadOnly())
    {
    }

    /// <inheritdoc/>
    public string ViewName => "Modal";

    /// <inheritdoc/>
    public IReadOnlyCollection<IComponent> GetComponents()
    {
        return Content;
    }
}