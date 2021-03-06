# ApplicationInsights.TelemetryLogger
An interface alternative TelemetryClient to facilitate testing via dependency inversion

[![nuget](https://img.shields.io/nuget/v/TomLonghurst.ApplicationInsights.TelemetryLogger.svg)](https://www.nuget.org/packages/TomLonghurst.ApplicationInsights.TelemetryLogger/)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/dbc34cf88c61441caa960579e1fd61ab)](https://www.codacy.com/gh/thomhurst/ApplicationInsights.TelemetryLogger/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=thomhurst/ApplicationInsights.TelemetryLogger&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/thomhurst/applicationinsights.telemetrylogger/badge)](https://www.codefactor.io/repository/github/thomhurst/applicationinsights.telemetrylogger)
<!-- ![Nuget](https://img.shields.io/nuget/dt/TomLonghurst.ApplicationInsights.TelemetryLogger) -->

## Support

If this library helped you, consider buying me a coffee

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

### Specific ITelemetryTypeLogger
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

### Custom Combined Specific Loggers
Maybe you care about tracking Events and Exceptions in your code, but nothing else.
Well, create a new interface (so you can add this to your Dependency Injection), and add to it the interfaces for the types you care about. E.g. `ITelemetryEventLogger` and `ITelemetryExceptionLogger`

Example: 

```csharp
 public interface IEventAndExceptionTelemetryLogger : ITelemetryEventLogger, ITelemetryExceptionLogger
    {
    }
```

Now create a new class, make it implement your custom interface, and then inject the built-in interfaces you added to your custom interface.
Then delegate all of the required methods to those new fields.

Example:

```csharp
public class CustomEventAndExceptionTelemetryLogger : IEventAndExceptionTelemetryLogger
    {
        private readonly ITelemetryEventLogger _telemetryEventLoggerImplementation;
        private readonly ITelemetryExceptionLogger _telemetryExceptionLoggerImplementation;

        public CustomEventAndExceptionTelemetryLogger(ITelemetryEventLogger telemetryEventLoggerImplementation, ITelemetryExceptionLogger telemetryExceptionLoggerImplementation)
        {
            _telemetryEventLoggerImplementation = telemetryEventLoggerImplementation;
            _telemetryExceptionLoggerImplementation = telemetryExceptionLoggerImplementation;
        }

        public void Flush()
        {
            _telemetryEventLoggerImplementation.Flush();
        }

        public Task<bool> FlushAsync(CancellationToken cancellationToken)
        {
            return _telemetryEventLoggerImplementation.FlushAsync(cancellationToken);
        }

        public TelemetryContext Context => _telemetryEventLoggerImplementation.Context;

        public void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            _telemetryEventLoggerImplementation.TrackEvent(eventName, properties, metrics);
        }

        public void TrackEvent(EventTelemetry telemetry)
        {
            _telemetryEventLoggerImplementation.TrackEvent(telemetry);
        }

        public void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            _telemetryExceptionLoggerImplementation.TrackException(exception, properties, metrics);
        }

        public void TrackException(ExceptionTelemetry telemetry)
        {
            _telemetryExceptionLoggerImplementation.TrackException(telemetry);
        }
    }
```

### Extension Methods
Extension methods should be registered to the specific `ITelemetryTypeLogger` interface. This is because the broader interface (`ITelemetryClient`) implements these specific interfaces. So this makes it available on any of the logger types that you inject.

```csharp
    public static class TelemetryExtensions
    {
        public static void LogSomethingHappenedTrace(this ITelemetryTraceLogger traceLogger)
        {
            traceLogger.TrackTrace("Something happened");
        }
    }

    public class MyClass
    {
        private readonly ITelemetryClient _telemetryClient;
        private readonly ITelemetryLogger _telemetryLogger;
        private readonly ITelemetryTraceLogger _traceLogger;

        public MyClass(ITelemetryClient telemetryClient, ITelemetryLogger telemetryLogger, ITelemetryTraceLogger traceLogger)
        {
            _telemetryClient = telemetryClient;
            _telemetryLogger = telemetryLogger;
            _traceLogger = traceLogger;
        }
        
        public void TelemetryClientExtension()
        {
            _telemetryClient.LogSomethingHappenedTrace();
        }
        
        public void TelemetryLoggerExtension()
        {
            _telemetryLogger.Traces.LogSomethingHappenedTrace();
        }
        
        public void TraceLoggerExtension()
        {
            _traceLogger.LogSomethingHappenedTrace();
        }
    }
```

Now Unit Test to your heart's content!
