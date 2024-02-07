namespace Rhythm.Drop.Web.Tests.TagHelperRenderers;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Modals;
using System.Collections.Generic;

internal class FakeModal : IModal
{
    public string ViewName => "Fake";

    public string UniqueKey => "fake";

    public IReadOnlyCollection<IComponent> Content => [ new FakeComponent() ];

    public IReadOnlyHtmlAttributeCollection Attributes => ReadOnlyHtmlAttributeCollection.Empty();

    public IReadOnlyCollection<IComponent> GetComponents()
    {
        return Content;
    }
}