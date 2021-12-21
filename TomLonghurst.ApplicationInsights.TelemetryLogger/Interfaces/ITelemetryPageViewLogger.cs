using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryPageViewLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackPageView(string name);
    void TrackPageView(PageViewTelemetry telemetry);
}