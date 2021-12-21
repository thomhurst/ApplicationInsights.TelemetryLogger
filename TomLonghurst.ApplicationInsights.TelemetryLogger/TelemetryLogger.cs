using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryLogger : ITelemetryLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryLogger(TelemetryClient telemetryClient, 
        ITelemetryEventLogger events, 
        ITelemetryRequestLogger requests, 
        ITelemetryTraceLogger traces, 
        ITelemetryDependencyLogger dependencies, 
        ITelemetryExceptionLogger exceptions, 
        ITelemetryMetricLogger metrics, 
        ITelemetryAvailabilityLogger availability, 
        ITelemetryPageViewLogger pageViews)
    {
        TelemetryClient = telemetryClient;
        Events = events;
        Requests = requests;
        Traces = traces;
        Dependencies = dependencies;
        Exceptions = exceptions;
        Metrics = metrics;
        Availability = availability;
        PageViews = pageViews;
    }

    public ITelemetryEventLogger Events { get; }

    public ITelemetryRequestLogger Requests { get; }

    public ITelemetryTraceLogger Traces { get; }

    public ITelemetryDependencyLogger Dependencies { get; }

    public ITelemetryExceptionLogger Exceptions { get; }

    public ITelemetryMetricLogger Metrics { get; }

    public ITelemetryAvailabilityLogger Availability { get; }

    public ITelemetryPageViewLogger PageViews { get; }

    public void Flush()
    {
        TelemetryClient.Flush();
    }

    public Task<bool> FlushAsync(CancellationToken cancellationToken)
    {
        return TelemetryClient.FlushAsync(cancellationToken);
    }
}