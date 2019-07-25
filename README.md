# Autodesk.Forge.DesignAutomation

[![Design-Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://developer.autodesk.com/) 
![SDK](https://img.shields.io/badge/SDK-3.0.0-lightgree.svg)
![.NET](https://img.shields.io/badge/.NET%20Standard-2.0-blue.svg)
![BUILD](https://codebuild.us-west-2.amazonaws.com/badges?uuid=eyJlbmNyeXB0ZWREYXRhIjoid1B4Tzk5R1h1emxsZjBjQm5NODNtYVgvL1drWnk3TVprN0MrK3YvTHBmcEk0UVphdzN3dVlvZktlcFA5S2V4NytvL3dmcXVwQkRnZXQwQkYrdXdWK29vPSIsIml2UGFyYW1ldGVyU3BlYyI6ImwyUXA0ODM0VFBBZnR0N2MiLCJtYXRlcmlhbFNldFNlcmlhbCI6MX0%3D&branch=master)

## Overview

.NET SDK for **Design Automation v3 API**, for more information, please visit  [official documentation](https://forge.autodesk.com/en/docs/design-automation/v3/)

For clients with straightforward needs one high level API client is provided in  [DesignAutomationClient](/src/Autodesk.Forge.DesignAutomation/ApiClient.gen.cs). For clients with more varied needs the following low level API classes are provided: [ActivitiesApi](/src/Autodesk.Forge.DesignAutomation/Http/ActivitiesApi.gen.cs), [AppBundlesApi](/src/Autodesk.Forge.DesignAutomation/Http/AppBundlesApi.gen.cs), [EnginesApi](/src/Autodesk.Forge.DesignAutomation/Http/EnginesApi.gen.cs),
[ForgeAppsApi](/src/Autodesk.Forge.DesignAutomation/Http/ForgeAppsApi.gen.cs), [HealthApi](/src/Autodesk.Forge.DesignAutomation/Http/HealthApi.gen.cs), [SharesApi](/src/Autodesk.Forge.DesignAutomation/Http/SharesApi.gen.cs), [WorkItemsApi](/src/Autodesk.Forge.DesignAutomation/Http/WorkItemsApi.gen.cs).


### Requirements

- [.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions.md) or later
- A registered app on the [Forge Developer Portal](http://forge.autodesk.com). 

### Dependencies

- [Autodesk.Forge.Core](https://github.com/autodesk-forge/forge-api-dotnet-core) assembly which provides services such as: 
    - Acquisition of [2 legged oauth token](https://forge.autodesk.com/en/docs/oauth/v2/tutorials/get-2-legged-token/) (and refreshing it when it expires) 
    - Preconfigurated resiliency patterns (e.g. retry) using [Polly](https://github.com/App-vNext/Polly)

### Changelog

The change log for the SDK can be found [here](../../releases).

### Contributions

Contributions are welcome! Please open a Pull Request.

## Support

Please ask questions on [StackOverflow](https://stackoverflow.com/questions/ask?tags=autodesk-designautomation,csharp) with tag `autodesk-designautomation` tag. If it turns out that you may have found a bug, please open an issue

## Getting Started

To use the API you must instantiate one of the API classes and configure it with the valid forge credentials. You can do this in 2 ways:
1. By using dependency injection and [configuration providers](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/#providers
) (PREFERRED)
2. By directly creating instances of one of API classes and the Autodesk.Forge.Core.ForgeConfiguration class and setting is properites

### Configuration

There are 2 classes that you can use to configure the API:

1. [Autodesk.Forge.Core.ForgeConfiguration](https://github.com/autodesk-forge/forge-api-dotnet-shared/blob/master/src/ForgeConfiguration.cs) - Allows the configuration of Forge client credentials and alternative authentication service endpoint (default is https://developer.api.autodesk.com/authentication/v1/authenticate)

2. [Autodesk.Forge.DesignAutomation.Configuration](src/Autodesk.Forge.DesignAutomation/Configuration.gen.cs)- Allows the configuration of non-default API endpoint (default is https://developer.api.autodesk.com/da/us-east/). 

This SDK integrates with the .netcore configuration system. You can configure the above values via any configuration provider (e.g. `appsettings.json` or environment variables).
For example to set the Forge credentials you could define the following environment variables:

```bash
Forge__ClientId=<your client id>
Forge__ClientSecret=<your client secret>
```

or the following in your `appsettings.json`:

```json
{
    "Forge": {
        "ClientId" : "<your client id>",
        "ClientSecret" : "<your client secret>"
    }
}
```

or using environment variables with `ForgeAlternativeConfigurationExtensions`:

```bash
FORGE_CLIENT_ID=<your client id>
FORGE_CLIENT_SECRET=<your client secret>
```
 
### Examples

#### Tutorials

Please visit [Learn Forge](https://learnforge.autodesk.io/#/tutorials/modifymodels) tutorial.

#### Using dependency injection
First you must add Autodesk.Forge.DesignAutomation services. This is usually done in `ConfigureServices(...)` method of your Startup class. [More information](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

__NOTE__: This example assumes that you are building an [Asp.Net Core](https://docs.microsoft.com/en-us/aspnet/core/) web api or website. 
If you want to use dependency injection in a console app then follow [this example](https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-net-core-2/).

```csharp
using Autodesk.Forge.DesignAutomation;
using Autodesk.Forge.DesignAutomation.Model;
...
public void ConfigureServices(IServiceCollection services)
{
    services.AddDesignAutomation(this.Configuration);
}
```

Then you can use any of the API classes or interfaces in a constructor:

```csharp
using Autodesk.Forge.DesignAutomation;
...
public class SomeApiController : ControllerBase
{
    public SomeApiController(IWorkItemsApi forgeApi)
    {
        //use forgeApi here
    }
```

#### By directly creating API objects

```csharp
using Autodesk.Forge.DesignAutomation;
using System.Net.Http;
using System.Threading.Tasks;
using Autodesk.Forge.Core;

internal class Program
{
    public static void Main(string[] args)
    {
        var service =
            new ForgeService(
                new HttpClient(
                    new ForgeHandler(Microsoft.Extensions.Options.Options.Create(new ForgeConfiguration()
                    {
                        ClientId = "<your client id>",
                        ClientSecret = "<your client secret>"
                    }))
                {
                    InnerHandler = new HttpClientHandler()
                })
            );

        var forgeApi = new WorkItemsApi(service);
    }
}
```

## Versioning

Using [Semantic Version](https://semver.org/) scheme following the pattern of `x.y.z.`:

- `x`: MAJOR version when you make incompatible changes,
- `y`: MINOR version when you add functionality in a backwards-compatible manner, and
- `z`: PATCH version when you make backwards-compatible bug fixes.

## Source-code

Generated with [swagger-codegen](https://github.com/swagger-api/swagger-codegen).

#### Build
```
dotnet build Autodesk.Forge.DesignAutomation.sln
```

#### Test
```
dotnet test Autodesk.Forge.DesignAutomation.sln
```


## License

This sample is licensed under the terms of the **Apache License 2.0**. Please see the [LICENSE](LICENSE) file for full details.