using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Implementations;

public class TelemetryAvailabilityLogger : ITelemetryAvailabilityLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryAvailabilityLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackAvailability(string name, DateTimeOffset timeStamp, TimeSpan duration, string runLocation, bool success,
        string? message = null, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        TelemetryClient.TrackAvailability(name, timeStamp, duration, runLocation, success, message, properties, metrics);
    }

    public void TrackAvailability(AvailabilityTelemetry telemetry)
    {
        TelemetryClient.TrackAvailability(telemetry);
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