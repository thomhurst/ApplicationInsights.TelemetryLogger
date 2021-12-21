using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Implementations;

public class TelemetryExceptionLogger : ITelemetryExceptionLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryExceptionLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        TelemetryClient.TrackException(exception, properties, metrics);
    }

    public void TrackException(ExceptionTelemetry telemetry)
    {
        TelemetryClient.TrackException(telemetry);
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