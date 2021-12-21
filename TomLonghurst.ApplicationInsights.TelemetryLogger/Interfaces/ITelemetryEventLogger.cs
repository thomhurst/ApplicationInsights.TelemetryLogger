﻿using System.Collections.Generic;
using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryEventLogger : IFlushableTelemetryLogger
{
    void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);
    void TrackEvent(EventTelemetry telemetry);
}