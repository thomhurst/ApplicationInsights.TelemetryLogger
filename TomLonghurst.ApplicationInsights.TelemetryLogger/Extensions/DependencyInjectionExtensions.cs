using Microsoft.Extensions.DependencyInjection;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationInsightsTelemetryClientInterfaces(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<ITelemetryLogger, TelemetryLogger>()
            .AddSingleton<ITelemetryClient, TelemetryClientWrapper>()
            .AddSingleton<ITelemetryEventLogger, TelemetryEventLogger>()
            .AddSingleton<ITelemetryRequestLogger, TelemetryRequestLogger>()
            .AddSingleton<ITelemetryTraceLogger, TelemetryTraceLogger>()
            .AddSingleton<ITelemetryDependencyLogger, TelemetryDependencyLogger>()
            .AddSingleton<ITelemetryExceptionLogger, TelemetryExceptionLogger>()
            .AddSingleton<ITelemetryMetricLogger, TelemetryMetricLogger>()
            .AddSingleton<ITelemetryAvailabilityLogger, TelemetryAvailabilityLogger>()
            .AddSingleton<ITelemetryPageViewLogger, TelemetryPageViewLogger>();
    }
}