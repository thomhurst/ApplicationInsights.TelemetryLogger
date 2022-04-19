using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Metrics;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryMetricLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackMetric(string name, double value, IDictionary<string, string>? properties = null);
    void TrackMetric(MetricTelemetry telemetry);
    
    IMetric GetMetric(
        string metricId);

    IMetric GetMetric(
        string metricId,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        string metricId,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    IMetric GetMetric(
        string metricId,
        string dimension1Name);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    IMetric GetMetric(
        MetricIdentifier metricIdentifier);

    IMetric GetMetric(
        MetricIdentifier metricIdentifier,
        MetricConfiguration metricConfiguration);

    IMetric GetMetric(
        MetricIdentifier metricIdentifier,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);
}