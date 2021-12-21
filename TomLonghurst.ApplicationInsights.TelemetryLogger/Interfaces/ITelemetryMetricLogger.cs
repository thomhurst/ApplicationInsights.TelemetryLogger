using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Metrics;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface ITelemetryMetricLogger : IFlushableTelemetryLogger, ITelemetryContextLogger
{
    void TrackMetric(string name, double value, IDictionary<string, string>? properties = null);
    void TrackMetric(MetricTelemetry telemetry);
    
    Metric GetMetric(
        string metricId);

    Metric GetMetric(
        string metricId,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        string metricId,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    Metric GetMetric(
        string metricId,
        string dimension1Name);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        string metricId,
        string dimension1Name,
        string dimension2Name,
        string dimension3Name,
        string dimension4Name,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);

    Metric GetMetric(
        MetricIdentifier metricIdentifier);

    Metric GetMetric(
        MetricIdentifier metricIdentifier,
        MetricConfiguration metricConfiguration);

    Metric GetMetric(
        MetricIdentifier metricIdentifier,
        MetricConfiguration metricConfiguration,
        MetricAggregationScope aggregationScope);
}