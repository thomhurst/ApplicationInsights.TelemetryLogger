using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Metrics;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryClientWrapper : ITelemetryClient
{
    private readonly TelemetryClient _telemetryClient;

    public TelemetryClientWrapper(TelemetryClient telemetryClient)
    {
        _telemetryClient = telemetryClient;
    }

    public bool IsEnabled()
    {
        return _telemetryClient.IsEnabled();
    }

    public void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        _telemetryClient.TrackEvent(eventName, properties, metrics);
    }

    public void TrackEvent(EventTelemetry telemetry)
    {
        _telemetryClient.TrackEvent(telemetry);
    }

    public void TrackTrace(string message)
    {
        _telemetryClient.TrackTrace(message);
    }

    public void TrackTrace(string message, SeverityLevel severityLevel)
    {
        _telemetryClient.TrackTrace(message, severityLevel);
    }

    public void TrackTrace(string message, IDictionary<string, string> properties)
    {
        _telemetryClient.TrackTrace(message, properties);
    }

    public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
    {
        _telemetryClient.TrackTrace(message, severityLevel, properties);
    }

    public void TrackTrace(TraceTelemetry telemetry)
    {
        _telemetryClient.TrackTrace(telemetry);
    }

    public void TrackMetric(string name, double value, IDictionary<string, string>? properties = null)
    {
        _telemetryClient.TrackMetric(name, value, properties);
    }

    public void TrackMetric(MetricTelemetry telemetry)
    {
        _telemetryClient.TrackMetric(telemetry);
    }

    public void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        _telemetryClient.TrackException(exception, properties, metrics);
    }

    public void TrackException(ExceptionTelemetry telemetry)
    {
        _telemetryClient.TrackException(telemetry);
    }

    public void TrackDependency(string dependencyTypeName, string dependencyName, string data, DateTimeOffset startTime,
        TimeSpan duration, bool success)
    {
        _telemetryClient.TrackDependency(dependencyTypeName, dependencyName, data, startTime, duration, success);
    }

    public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data,
        DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success)
    {
        _telemetryClient.TrackDependency(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);
    }

    public void TrackDependency(DependencyTelemetry telemetry)
    {
        _telemetryClient.TrackDependency(telemetry);
    }

    public void TrackAvailability(string name, DateTimeOffset timeStamp, TimeSpan duration, string runLocation, bool success,
        string? message = null, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
    {
        _telemetryClient.TrackAvailability(name, timeStamp, duration, runLocation, success, message, properties, metrics);
    }

    public void TrackAvailability(AvailabilityTelemetry telemetry)
    {
        _telemetryClient.TrackAvailability(telemetry);
    }

    public void TrackPageView(string name)
    {
        _telemetryClient.TrackPageView(name);
    }

    public void TrackPageView(PageViewTelemetry telemetry)
    {
        _telemetryClient.TrackPageView(telemetry);
    }

    public void TrackRequest(string name, DateTimeOffset startTime, TimeSpan duration, string responseCode, bool success)
    {
        _telemetryClient.TrackRequest(name, startTime, duration, responseCode, success);
    }

    public void TrackRequest(RequestTelemetry request)
    {
        _telemetryClient.TrackRequest(request);
    }

    public void Flush()
    {
        _telemetryClient.Flush();
    }

    public Task<bool> FlushAsync(CancellationToken cancellationToken)
    {
        return _telemetryClient.FlushAsync(cancellationToken);
    }

    public Metric GetMetric(string metricId)
    {
        return _telemetryClient.GetMetric(metricId);
    }

    public Metric GetMetric(string metricId, MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricId, metricConfiguration);
    }

    public Metric GetMetric(string metricId, MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricId, metricConfiguration, aggregationScope);
    }

    public Metric GetMetric(string metricId, string dimension1Name)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name);
    }

    public Metric GetMetric(string metricId, string dimension1Name, MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, metricConfiguration);
    }

    public Metric GetMetric(string metricId, string dimension1Name, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, metricConfiguration, aggregationScope);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name,
        MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, metricConfiguration);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, metricConfiguration, aggregationScope);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, metricConfiguration);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, metricConfiguration, aggregationScope);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name, MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name, metricConfiguration);
    }

    public Metric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name, MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name, metricConfiguration, aggregationScope);
    }

    public Metric GetMetric(MetricIdentifier metricIdentifier)
    {
        return _telemetryClient.GetMetric(metricIdentifier);
    }

    public Metric GetMetric(MetricIdentifier metricIdentifier, MetricConfiguration metricConfiguration)
    {
        return _telemetryClient.GetMetric(metricIdentifier, metricConfiguration);
    }

    public Metric GetMetric(MetricIdentifier metricIdentifier, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return _telemetryClient.GetMetric(metricIdentifier, metricConfiguration, aggregationScope);
    }

    public TelemetryContext Context => _telemetryClient.Context;

    public string InstrumentationKey
    {
        get => _telemetryClient.InstrumentationKey;
        set => _telemetryClient.InstrumentationKey = value;
    }

    public TelemetryConfiguration TelemetryConfiguration => _telemetryClient.TelemetryConfiguration;
}