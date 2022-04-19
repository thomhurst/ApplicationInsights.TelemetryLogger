using Microsoft.ApplicationInsights.DataContracts;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryDependencyLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackDependency(DependencyTelemetry telemetry);

    void TrackDependency(string dependencyTypeName, string dependencyName, string data, DateTimeOffset startTime,
        TimeSpan duration, bool success);

    void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data,
        DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success);
}