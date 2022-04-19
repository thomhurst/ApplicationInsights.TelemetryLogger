using Microsoft.ApplicationInsights;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Extensions;

internal static class MetricExtensions
{
    public static IMetric WrapMetric(this Metric metric)
    {
        return new MetricWrapper(metric);
    }
}