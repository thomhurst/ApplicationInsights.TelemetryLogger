using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryExceptionLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);
    void TrackException(ExceptionTelemetry telemetry);
}