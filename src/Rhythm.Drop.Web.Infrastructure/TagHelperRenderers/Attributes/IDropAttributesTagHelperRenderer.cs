namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Attributes;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A contract for rendering <see cref="IHtmlAttributeCollectionBase"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public interface IDropAttributesTagHelperRenderer : ITagHelperRenderer<IHtmlAttributeCollectionBase>
{
}