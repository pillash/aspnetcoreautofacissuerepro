# aspnetcoreautofacissuerepro
An ASP.NET core app that repros and issue I'm facing with AddHttpClient and Autofac

The setup: 
* `HomeController` that depends on `ILogger` and `IClient`
* `ILogger` that depends on an integer logger ID that is injected per request. This is registered with `InstancePerLifetimeScope`
* `IClient` that depends on `HttpClient` and `ILogger`. This is registered with ASP.NET Core's `AddHttpClient`

The issue: While `IClient` is instantiated once per request (can verify by putting breakpoint in its constructor), the `ILogger` injected into it is the same for each request. I would expect it to be a new `ILogger` per request since I registered it with `InstancePerLifetimeScope`.

This can be seen by refreshing the page multiple times and looking at the console logs. For each request, you will see the same log
> Logger id: 2. => from Client

along with a "from HomeController" log with incrementing logger id. This shows that a new `ILogger` is injected into HomeController each request, but the same `ILogger` is injected into `Client`.
