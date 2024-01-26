namespace Rhythm.Drop.Web.TagHelpers;

using Rhythm.Drop.Models.Images;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Web.Infrastructure;

/// <summary>
/// A base tag helper used to render a <see cref="IImage"/> a picture HTML tag.
/// </summary>
public abstract class DropImageTagHelperBase : TagHelper
{
    /// <summary>
    /// The tag name of a picture HTML tag.
    /// </summary>
    protected const string PictureTagName = "picture";

    /// <summary>
    /// The tag name of an img HTML tag.
    /// </summary>
    protected const string ImgTagName = "img";

    /// <summary>
    /// The attribute name used to get the <see cref="IImage"/> model.
    /// </summary>
    protected const string DropModelAttributeName = "drop-model";

    /// <summary>
    /// The attribute name used to get the <see cref="LoadingMode"/>.
    /// </summary>
    protected const string LoadingModeAttributeName = "loading-mode";

    /// <summary>
    /// The name of the context item used to get and set the <see cref="IImage"/>.
    /// </summary>
    protected const string DropModelContextItemName = "Drop-Model";

    /// <summary>
    /// The name of the context item used to get and set the <see cref="LoadingMode"/>.
    /// </summary>
    protected const string DropLoadingModeContextItemName = "Drop-LoadingMode";
}