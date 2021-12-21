# ApplicationInsights.TelemetryLogger
An interface alternative TelemetryClient to facilitate testing via dependency inversion

[![nuget](https://img.shields.io/nuget/v/TomLonghurst.ApplicationInsights.TelemetryLogger.svg)](https://www.nuget.org/packages/TomLonghurst.ApplicationInsights.TelemetryLogger/)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/dbc34cf88c61441caa960579e1fd61ab)](https://www.codacy.com/gh/thomhurst/ApplicationInsights.TelemetryLogger/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=thomhurst/ApplicationInsights.TelemetryLogger&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/thomhurst/applicationinsights.telemetrylogger/badge)](https://www.codefactor.io/repository/github/thomhurst/applicationinsights.telemetrylogger)
<!-- ![Nuget](https://img.shields.io/nuget/dt/TomLonghurst.ApplicationInsights.TelemetryLogger) -->

### Support

If you like using BDTest, consider buying me a coffee :)

<a href="https://www.buymeacoffee.com/tomhurst" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

## Installation
Install via Nuget
`Install-Package TomLonghurst.ApplicationInsights.TelemetryLogger`

## Usage
### Dependency Injection

Call `AddApplicationInsightsTelemetry()` as normal, and then call `AddApplicationInsightsTelemetryClientInterfaces()`

```csharp
public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationInsightsTelemetry()
            .AddApplicationInsightsTelemetryClientInterfaces();
    }
```

### ITelemetryClient
Want the same usage as TelemetryClient? Inject ITelemetryClient into your classes. It has all the available methods of TelemetryClient (apart from any methods which shouldn't be called. e.g. internal or deprecated).

```csharp
public class MyClass
{
    private readonly ITelemetryClient _telemetryClient;

    public MyClass(ITelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }
    
    public void DoSomething()
    {
        _telemetryClient.TrackTrace("Something happened");
    }
}
```

### ITelemetryLogger
ITelemetryLogger behaves much the same as ITelemetryClient, it's just slightly more organised. Containing inner loggers for Trace, Events, etc.

```csharp
public class MyClass
{
    private readonly ITelemetryLogger _telemetryLogger;

    public MyClass(ITelemetryLogger telemetryLogger)
    {
        _telemetryLogger = telemetryLogger;
    }

    public void DoSomething()
    {
        _telemetryLogger.Traces.TrackTrace("Something happened");
    }
}
```

### Specific ITelemetry[Type]Logger
Just inject the type you care about.

```csharp
ITelemetryAvailabilityLogger
ITelemetryEventLogger
ITelemetryDependencyLogger
ITelemetryRequestLogger
ITelemetryTraceLogger
ITelemetryPageViewLogger
ITelemetryMetricLogger
ITelemetryExceptionLogger
```

```csharp
public class MyClass
{
    private readonly ITelemetryTraceLogger _traceLogger;

    public MyClass(ITelemetryTraceLogger traceLogger)
    {
        _traceLogger = traceLogger;
    }

    public void DoSomething()
    {
        _traceLogger.TrackTrace("Something happened");
    }
}
```

Now Unit Test to your heart's content!
