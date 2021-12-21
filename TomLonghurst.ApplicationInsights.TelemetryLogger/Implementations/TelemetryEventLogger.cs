using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Implementations;

public class TelemetryEventLogger : ITelemetryEventLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryEventLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        TelemetryClient.TrackEvent(eventName, properties, metrics);
    }

    public void TrackEvent(EventTelemetry telemetry)
    {
        TelemetryClient.TrackEvent(telemetry);
    }

    public void Flush()
    {
        TelemetryClient.Flush();
    }

    public Task<bool> FlushAsync(CancellationToken cancellationToken)
    {
        return TelemetryClient.FlushAsync(cancellationToken);
    }
}