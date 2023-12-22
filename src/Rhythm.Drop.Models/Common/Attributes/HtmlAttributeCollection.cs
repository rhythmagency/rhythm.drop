namespace Rhythm.Drop.Models.Common.Attributes;

using System;

/// <summary>
/// An implementation of <see cref="IHtmlAttributeCollectionBase"/> ready for modifications.
/// </summary>
public sealed class HtmlAttributeCollection : HtmlAttributeCollectionBase, IHtmlAttributeCollection
{
    private const string ClassAttributeName = "class";

    /// <summary>
    /// Constructs an empty <see cref="HtmlAttributeCollection"/>.
    /// </summary>
    public HtmlAttributeCollection() : base()
    {
    }

    /// <summary>
    /// Constructs a <see cref="HtmlAttributeCollection"/> from an existing collection.
    /// </summary>
    /// <param name="attributes">The existing collection.</param>
    public HtmlAttributeCollection(IHtmlAttributeCollectionBase attributes) : base(attributes)
    {
    }

    /// <inheritdoc/>
    public void AddClass(string className)
    {
        if (_dictionary.TryGetValue(ClassAttributeName, out var value) is false)
        {
            SetAttribute(ClassAttributeName, className);
        }
        else if (value is not null)
        {
            var valueAsString = value.ToString() ?? string.Empty;
            var classes = valueAsString.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            if (classes.Contains(className) is false)
            {
                classes.Add(className);
                var classesFormatted = string.Join(" ", classes);
                SetAttribute(ClassAttributeName, classesFormatted);
            }
        }
    }

    /// <inheritdoc/>
    public void RemoveAll()
    {
        _dictionary.Clear();
    }

    /// <inheritdoc/>
    public bool RemoveAttribute(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        return _dictionary.Remove(name);
    }

    /// <inheritdoc/>
    public void RemoveClass(string className)
    {
        if (_dictionary.TryGetValue(ClassAttributeName, out var value) is false)
        {
            SetAttribute(ClassAttributeName, className);
        }
        else if (value is not null)
        {
            var valueAsString = value.ToString() ?? string.Empty;
            var classes = valueAsString.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            classes.Remove(className);
            var classesFormatted = string.Join(" ", classes).Trim();

            if (string.IsNullOrWhiteSpace(classesFormatted))
            {
                RemoveAttribute(ClassAttributeName);
            }
            else
            {
                SetAttribute(ClassAttributeName, classesFormatted);
            }
        }
    }

    /// <inheritdoc/>
    public void SetAttribute(string name, object? value)
    {
        if (string.IsNullOrEmpty(name))
        {
            return;
        }

        _dictionary[name] = value;
    }

    /// <inheritdoc/>
    public void SetAttributes(IHtmlAttributeCollectionBase attributes)
    {
        foreach (var attribute in attributes)
        {
            SetAttribute(attribute.Name, attribute.Value);
        }
    }

    /// <inheritdoc/>
    public void SetAttributes(IReadOnlyCollection<KeyValuePair<string, object?>> kvps)
    {
        foreach (var kvp in kvps)
        {
            SetAttribute(kvp.Key, kvp.Value);
        }
    }

    /// <inheritdoc/>
    public IReadOnlyHtmlAttributeCollection ToReadOnly()
    {
        return new ReadOnlyHtmlAttributeCollection(this);
    }
}