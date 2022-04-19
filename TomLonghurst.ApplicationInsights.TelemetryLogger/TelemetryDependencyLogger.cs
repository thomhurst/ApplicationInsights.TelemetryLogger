using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryDependencyLogger : ITelemetryDependencyLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryDependencyLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackDependency(string dependencyTypeName, string dependencyName, string data, DateTimeOffset startTime,
        TimeSpan duration, bool success)
    {
        TelemetryClient.TrackDependency(dependencyTypeName, dependencyName, data, startTime, duration, success);
    }

    public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data,
        DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
    {
        TelemetryClient.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
    }

    public void TrackDependency(DependencyTelemetry telemetry)
    {
        TelemetryClient.TrackDependency(telemetry);
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