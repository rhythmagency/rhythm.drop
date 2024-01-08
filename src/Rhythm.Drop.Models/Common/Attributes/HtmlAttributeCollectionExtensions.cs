namespace Rhythm.Drop.Models.Common.Attributes;

using System;

/// <summary>
/// A collection of methods to augment implementations of <see cref="IHtmlAttributeCollection"/>.
/// </summary>
public static class HtmlAttributeCollectionExtensions
{
    private const string ClassAttributeName = "class";

    /// <summary>
    /// Adds a class name to the current <see cref="IHtmlAttributeCollection"/>.
    /// </summary>
    /// <param name="attributes">The current attributes collection.</param>
    /// <param name="className">The class name to add.</param>
    public static void AddClass(this IHtmlAttributeCollection attributes, string className)
    {
        if (attributes.HasAttribute(ClassAttributeName) is false)
        {
            attributes.SetAttribute(ClassAttributeName, className);
            return;
        }

        if (attributes.TryGetValue<string>(ClassAttributeName, out var value) is false)
        {
            attributes.SetAttribute(ClassAttributeName, className);
            return;
        }

        var classes = value.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        if (classes.Contains(className))
        {
            return;
        }

        classes.Add(className);
        var classesFormatted = string.Join(" ", classes);
        attributes.SetAttribute(ClassAttributeName, classesFormatted);
    }

    /// <summary>
    /// Removes a class name to the current <see cref="IHtmlAttributeCollection"/>.
    /// </summary>
    /// <param name="attributes">The current attributes collection.</param>
    /// <param name="className">The class name to remove.</param>
    public static void RemoveClass(this IHtmlAttributeCollection attributes, string className)
    {
        if (attributes.HasAttribute(ClassAttributeName) is false)
        {
            return;
        }

        if (attributes.TryGetValue<string>(ClassAttributeName, out var value) is false)
        {
            return;
        }

        var classes = value.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
        classes.Remove(className);
        var classesFormatted = string.Join(" ", classes).Trim();

        if (string.IsNullOrWhiteSpace(classesFormatted))
        {
            attributes.RemoveAttribute(ClassAttributeName);
            return;
        }

        attributes.SetAttribute(ClassAttributeName, classesFormatted);
    }
}
