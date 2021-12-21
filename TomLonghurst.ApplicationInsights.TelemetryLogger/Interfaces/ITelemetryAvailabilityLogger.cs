using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryAvailabilityLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackAvailability(string name, DateTimeOffset timeStamp, TimeSpan duration, string runLocation,
        bool success, string? message = null, IDictionary<string, string>? properties = null,
        IDictionary<string, double>? metrics = null);

    void TrackAvailability(AvailabilityTelemetry telemetry);
}