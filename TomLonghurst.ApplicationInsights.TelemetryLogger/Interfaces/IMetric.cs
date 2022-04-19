using Microsoft.ApplicationInsights.Metrics;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface IMetric
{
    IReadOnlyCollection<string> GetDimensionValues(int dimensionNumber);

    IReadOnlyList<KeyValuePair<string[], MetricSeries>> GetAllSeries();

    bool TryGetDataSeries(out MetricSeries series);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value);

    bool TryGetDataSeries(out MetricSeries series, string dimension1Value, string dimension2Value,
        string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value);

    bool TryGetDataSeries(out MetricSeries series, bool createIfNotExists, params string[] dimensionValues);

    void TrackValue(double metricValue);

    void TrackValue(object metricValue);

    bool TrackValue(double metricValue, string dimension1Value);

    bool TrackValue(object metricValue, string dimension1Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value);

    bool TrackValue(double metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value);

    bool TrackValue(object metricValue, string dimension1Value, string dimension2Value, string dimension3Value,
        string dimension4Value, string dimension5Value, string dimension6Value, string dimension7Value,
        string dimension8Value, string dimension9Value, string dimension10Value);

    MetricIdentifier Identifier { get; }

    int SeriesCount { get; }
}