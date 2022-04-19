using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryEventLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);
    void TrackEvent(EventTelemetry telemetry);
}