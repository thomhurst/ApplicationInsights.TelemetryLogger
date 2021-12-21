﻿using System.Collections.Generic;
using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryTraceLogger : IFlushableTelemetryLogger
{
    void TrackTrace(string message);
    void TrackTrace(string message, SeverityLevel severityLevel);
    void TrackTrace(string message, IDictionary<string, string> properties);
    void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties);
    void TrackTrace(TraceTelemetry telemetry);
}