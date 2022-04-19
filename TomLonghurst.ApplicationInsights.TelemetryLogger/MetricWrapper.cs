using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger;

public class MetricWrapper : IMetric
{
    private readonly Metric _metric;

    public MetricWrapper(Metric metric)
    {
        _metric = metric;
    }

    public IReadOnlyCollection<string> GetDimensionValues(int dimensionNumber)
    {
        return _metric.GetDimensionValues(dimensionNumber);
    }

    public IReadOnlyList<KeyValuePair<string[], MetricSeries>> GetAllSeries()
    {
        return _metric.GetAllSeries();
    }

    public bool TryGetDataSeries(out MetricSeries series)
    {
        return _metric.TryGetDataSeries(out series);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value)
    {
        return _metric.TryGetDataSeries(out series, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value, dimension10Value);
    }

    public bool TryGetDataSeries(out MetricSeries series, bool createIfNotExists, params string[] dimensionValues)
    {
        return _metric.TryGetDataSeries(out series, createIfNotExists, dimensionValues);
    }

    public void TrackValue(double metricValue)
    {
        _metric.TrackValue(metricValue);
    }

    public void TrackValue(object metricValue)
    {
        _metric.TrackValue(metricValue);
    }

    public bool TrackValue(double metricValue, string dimension1Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value);
    }

    public bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value, dimension10Value);
    }

    public bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value)
    {
        return _metric.TrackValue(metricValue, dimension1Value, dimension2Value, dimension3Value, dimension4Value, dimension5Value, dimension6Value, dimension7Value, dimension8Value, dimension9Value, dimension10Value);
    }

    public MetricIdentifier Identifier => _metric.Identifier;

    public int SeriesCount => _metric.SeriesCount;
}