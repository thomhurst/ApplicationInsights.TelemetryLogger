using System.Threading;
using System.Threading.Tasks;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

public interface IFlushableTelemetryLogger
{
    void Flush();
    Task<bool> FlushAsync(CancellationToken cancellationToken);
}