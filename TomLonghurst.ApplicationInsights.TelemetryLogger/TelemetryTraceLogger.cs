using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryTraceLogger : ITelemetryTraceLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryTraceLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackTrace(string message)
    {
        TelemetryClient.TrackTrace(message);
    }

    public void TrackTrace(string message, SeverityLevel severityLevel)
    {
        TelemetryClient.TrackTrace(message, severityLevel);
    }

    public void TrackTrace(string message, IDictionary<string, string> properties)
    {
        TelemetryClient.TrackTrace(message, properties);
    }

    public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
    {
        TelemetryClient.TrackTrace(message, severityLevel, properties);
    }

    public void TrackTrace(TraceTelemetry telemetry)
    {
        TelemetryClient.TrackTrace(telemetry);
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