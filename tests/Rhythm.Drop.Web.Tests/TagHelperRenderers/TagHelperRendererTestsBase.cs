namespace Rhythm.Drop.Web.Tests.TagHelperRenderers;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// A base class for creating tests for Tag Helper Renderers.
/// </summary>
public abstract class TagHelperRendererTestsBase
{
    protected const string DefaultTagName = "div";

    /// <summary>
    /// Creates a <see cref="TagHelperContext"/> with a tag name and attributes.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <param name="attributes">The attributes</param>
    /// <returns>A <see cref="TagHelperContext"/>.</returns>
    protected static TagHelperContext CreateTagHelperContext(string tagName, IEnumerable<TagHelperAttribute> attributes)
    {
        return new TagHelperContext(tagName, new TagHelperAttributeList(attributes), new Dictionary<object, object>(), Guid.NewGuid().ToString());
    }

    /// <summary>
    /// Creates a <see cref="TagHelperContext"/> with a tag name.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <param name="attributes">The attributes</param>
    /// <returns>A <see cref="TagHelperContext"/>.</returns>
    protected static TagHelperContext CreateTagHelperContext(string tagName)
    {
        return CreateTagHelperContext(tagName, []);
    }

    /// <summary>
    /// Creates a <see cref="TagHelperOutput"/> with a tag name, attributes and HTML content.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <param name="attributes">The attributes</param>
    /// <param name="htmlContent">The HTML content.</param>
    /// <returns>A <see cref="TagHelperOutput"/>.</returns>
    protected static TagHelperOutput CreateTagHelperOutput(string tagName, IEnumerable<TagHelperAttribute> attributes, IHtmlContent? htmlContent)
    {
        return new TagHelperOutput(tagName, new TagHelperAttributeList(attributes), (useCachedResult, encoder) =>
        {
            var tagHelperContent = new DefaultTagHelperContent();

            if (htmlContent is not null)
            {
                tagHelperContent.SetHtmlContent(htmlContent);
            }

            return Task.FromResult<TagHelperContent>(tagHelperContent);
        });
    }

    /// <summary>
    /// Creates a <see cref="TagHelperOutput"/> with a tag name and HTML content.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <param name="htmlContent">The HTML content.</param>
    /// <returns>A <see cref="TagHelperOutput"/>.</returns>
    protected static TagHelperOutput CreateTagHelperOutput(string tagName, IHtmlContent? htmlContent)
    {
        return CreateTagHelperOutput(tagName, [], htmlContent);
    }

    /// <summary>
    /// Creates a <see cref="TagHelperOutput"/> with a tag name and HTML content.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <param name="attributes">The attributes</param>
    /// <returns>A <see cref="TagHelperOutput"/>.</returns>
    protected static TagHelperOutput CreateTagHelperOutput(string tagName, IEnumerable<TagHelperAttribute> attributes)
    {
        return CreateTagHelperOutput(tagName, attributes, default);
    }

    /// <summary>
    /// Creates a <see cref="TagHelperOutput"/> with a tag name and HTML content.
    /// </summary>
    /// <param name="tagName">The tag name.</param>
    /// <returns>A <see cref="TagHelperOutput"/>.</returns>
    protected static TagHelperOutput CreateTagHelperOutput(string tagName)
    {
        return CreateTagHelperOutput(tagName, [], default);
    }
}
