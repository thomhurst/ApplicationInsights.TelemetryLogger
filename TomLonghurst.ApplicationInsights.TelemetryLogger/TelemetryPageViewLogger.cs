using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryPageViewLogger : ITelemetryPageViewLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryPageViewLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackPageView(string name)
    {
        TelemetryClient.TrackPageView(name);
    }

    public void TrackPageView(PageViewTelemetry telemetry)
    {
        TelemetryClient.TrackPageView(telemetry);
    }
    
    public void Flush()
    {
        TelemetryClient.Flush();
    }

    public Task<bool> FlushAsync(CancellationToken cancellationToken)
    {
        return TelemetryClient.FlushAsync(cancellationToken);
    }
    
    public TelemetryContext Context => TelemetryClient.Context;
}