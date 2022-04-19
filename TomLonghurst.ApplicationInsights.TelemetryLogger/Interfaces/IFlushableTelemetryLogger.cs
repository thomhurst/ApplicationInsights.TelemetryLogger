namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface IFlushableTelemetryLogger
{
    void Flush();
    Task<bool> FlushAsync(CancellationToken cancellationToken);
}