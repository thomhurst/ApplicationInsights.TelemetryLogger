using System;
using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryRequestLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode,
        bool success);

    void TrackRequest(RequestTelemetry request);
}