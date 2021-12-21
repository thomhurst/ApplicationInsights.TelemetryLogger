using Microsoft.ApplicationInsights.Extensibility;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryClient : ITelemetryAvailabilityLogger, ITelemetryEventLogger, ITelemetryDependencyLogger, ITelemetryRequestLogger, ITelemetryTraceLogger, ITelemetryPageViewLogger, ITelemetryMetricLogger, ITelemetryExceptionLogger
{
    TelemetryConfiguration TelemetryConfiguration { get; }
    string InstrumentationKey { get; set; }
    bool IsEnabled();
}