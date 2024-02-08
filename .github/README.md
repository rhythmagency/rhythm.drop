# rhythm.drop [![Publish to NuGet](https://github.com/rhythmagency/rhythm.drop/actions/workflows/Publish-to-NuGet.yml/badge.svg)](https://github.com/rhythmagency/rhythm.drop/actions/workflows/Publish-to-NuGet.yml) [![NuGet](https://img.shields.io/nuget/v/Rhythm.Drop?logo=nuget)](https://www.nuget.org/packages/Rhythm.Drop)
A .net library for common data building and rendering tasks.

## Startup

To get started with Rhythm Drop you will be the following;

 - .net 8 web project
 - Install the Rhythm.Drop NuGet package

Once installed add the following to your Program.cs during the `WebApplicationBuilder` before `Build()` is called.

```csharp
builder.AddRhythmDrop();
```

Alternatively if you are using Startup.cs `ConfigureServices(IServiceCollection services)` add the following:

```csharp
public void ConfigureServices(IServiceCollection services) {
    services.AddRhythmDrop();
}
```

## Custom startup

For modifications there is an overload which supports a `Action<IRhythmDropBuilder>` for configuring web and infrastructure dependencies. The defaults for these features will always be added first time `AddRhythmDrop` is called then followed by your override functionality.

```csharp
builder
    .AddRhythmDrop((dropBuilder) =>
    {
        dropBuilder.SetComponentMetaDataFactory<MyCustomComponentMetaDataFactory>()
                   .SetDropImageTagHelperRenderer<MyCustomDropImageTagHelperRenderer>();
    });
```

This overload is also supported by the `IServiceCollection` implementation too.

## Tag Helpers

Rhythm.Drop (via Rhythm.Drop.Web) comes with a collection of Tag Helpers. Register them in your application's *_ViewImports.cshtml* file:

```razor
@addTagHelper *, Rhythm.Drop.Web
```

It may also be useful to include the following namespace when using MetaData objects like `ComponentMetaData<TComponent>`, `ElementMetaData<TElement>`,  `ModalMetaData<TModal>`

```razor
@using Rhythm.Drop.Web.MetaData
```

This will allow you to reference these objects in your views like so:

```razor
@model ComponentMetaData<Namespace.To.MyComponent>
```