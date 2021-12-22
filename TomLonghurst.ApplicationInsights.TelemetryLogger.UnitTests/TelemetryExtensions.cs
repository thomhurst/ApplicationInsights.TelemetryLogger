using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.UnitTests
{
    public static class TelemetryExtensions
    {
        public static void LogSomethingHappenedTrace(this ITelemetryTraceLogger traceLogger)
        {
            traceLogger.TrackTrace("Something happened");
        }
    }
}