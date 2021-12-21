using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryPageViewLogger : IFlushableTelemetryLogger
{
    void TrackPageView(string name);
    void TrackPageView(PageViewTelemetry telemetry);
}