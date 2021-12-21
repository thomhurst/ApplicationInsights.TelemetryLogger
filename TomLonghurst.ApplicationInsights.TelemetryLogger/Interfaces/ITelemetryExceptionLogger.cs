using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryExceptionLogger : IFlushableTelemetryLogger
{
    void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);
    void TrackException(ExceptionTelemetry telemetry);
}