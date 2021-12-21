namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    ITelemetryEventLogger Events { get; }
    ITelemetryRequestLogger Requests { get; }
    ITelemetryTraceLogger Traces { get; }
    ITelemetryDependencyLogger Dependencies { get; }
    ITelemetryExceptionLogger Exceptions { get; }
    ITelemetryMetricLogger Metrics { get; }
    ITelemetryAvailabilityLogger Availability { get; }
    ITelemetryPageViewLogger PageViews { get; }
}