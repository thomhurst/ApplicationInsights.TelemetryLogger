# ApplicationInsights.TelemetryLogger
An interface alternative TelemetryClient to facilitate testing via dependency inversion

## Usage
### Dependency Injection

Call `AddApplicationInsightsTelemetry()` as normal, and then call `AddApplicationInsightsTelemetryLogger()`

```csharp
public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddApplicationInsightsTelemetry()
            .AddApplicationInsightsTelemetryLogger();
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

### Only care about a certain type of Telemetry?
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
