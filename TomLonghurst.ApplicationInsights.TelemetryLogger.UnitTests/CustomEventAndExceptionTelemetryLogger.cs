using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.DataContracts;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.UnitTests
{
    public class CustomEventAndExceptionTelemetryLogger : ITelemetryEventLogger, ITelemetryExceptionLogger
    {
        private readonly ITelemetryEventLogger _telemetryEventLoggerImplementation;
        private readonly ITelemetryExceptionLogger _telemetryExceptionLoggerImplementation;

        public CustomEventAndExceptionTelemetryLogger(ITelemetryEventLogger telemetryEventLoggerImplementation, ITelemetryExceptionLogger telemetryExceptionLoggerImplementation)
        {
            _telemetryEventLoggerImplementation = telemetryEventLoggerImplementation;
            _telemetryExceptionLoggerImplementation = telemetryExceptionLoggerImplementation;
        }

        public void Flush()
        {
            _telemetryEventLoggerImplementation.Flush();
        }

        public Task<bool> FlushAsync(CancellationToken cancellationToken)
        {
            return _telemetryEventLoggerImplementation.FlushAsync(cancellationToken);
        }

        public TelemetryContext Context => _telemetryEventLoggerImplementation.Context;

        public void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            _telemetryEventLoggerImplementation.TrackEvent(eventName, properties, metrics);
        }

        public void TrackEvent(EventTelemetry telemetry)
        {
            _telemetryEventLoggerImplementation.TrackEvent(telemetry);
        }

        public void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            _telemetryExceptionLoggerImplementation.TrackException(exception, properties, metrics);
        }

        public void TrackException(ExceptionTelemetry telemetry)
        {
            _telemetryExceptionLoggerImplementation.TrackException(telemetry);
        }
    }
}