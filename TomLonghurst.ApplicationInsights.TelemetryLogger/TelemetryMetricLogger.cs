using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Metrics;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Extensions;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class TelemetryMetricLogger : ITelemetryMetricLogger
{
    public TelemetryClient TelemetryClient { get; }

    public TelemetryMetricLogger(TelemetryClient telemetryClient)
    {
        TelemetryClient = telemetryClient;
    }

    public void TrackMetric(string name, double value, IDictionary<string, string>? properties = null)
    {
        TelemetryClient.TrackMetric(name, value, properties);
    }

    public void TrackMetric(MetricTelemetry telemetry)
    {
        TelemetryClient.TrackMetric(telemetry);
    }

    public IMetric GetMetric(string metricId)
    {
        return TelemetryClient.GetMetric(metricId).WrapMetric();
    }

    public IMetric GetMetric(string metricId, MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricId, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(string metricId, MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricId, metricConfiguration, aggregationScope).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, metricConfiguration, aggregationScope).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name,
        MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, metricConfiguration, aggregationScope).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, metricConfiguration, aggregationScope).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name, MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(string metricId, string dimension1Name, string dimension2Name, string dimension3Name,
        string dimension4Name, MetricConfiguration metricConfiguration, MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricId, dimension1Name, dimension2Name, dimension3Name, dimension4Name, metricConfiguration, aggregationScope).WrapMetric();
    }

    public IMetric GetMetric(MetricIdentifier metricIdentifier)
    {
        return TelemetryClient.GetMetric(metricIdentifier).WrapMetric();
    }

    public IMetric GetMetric(MetricIdentifier metricIdentifier, MetricConfiguration metricConfiguration)
    {
        return TelemetryClient.GetMetric(metricIdentifier, metricConfiguration).WrapMetric();
    }

    public IMetric GetMetric(MetricIdentifier metricIdentifier, MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope)
    {
        return TelemetryClient.GetMetric(metricIdentifier, metricConfiguration, aggregationScope).WrapMetric();
    }
    
    public void Flush()
    {
        TelemetryClient.Flush();
    }

    public Task<bool> FlushAsync(CancellationToken cancellationToken)
    {
        return TelemetryClient.FlushAsync(cancellationToken);
    }
    
    public TelemetryContext Context => TelemetryClient.Context;
}