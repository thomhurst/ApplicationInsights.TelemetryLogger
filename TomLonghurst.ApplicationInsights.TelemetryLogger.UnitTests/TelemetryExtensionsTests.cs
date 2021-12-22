using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Extensions;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Interfaces;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.UnitTests
{
    public class TelemetryExtensionsTests
    {
        private Mock<ITelemetryChannel> _telemetryChannel;
        private ITelemetryClient _telemetryClient;
        private ITelemetryLogger _telemetryLogger;
        private ITelemetryTraceLogger _traceLogger;

        [SetUp]
        public void Setup()
        {
            _telemetryChannel = new Mock<ITelemetryChannel>();
            
            var telemetryClient = new TelemetryClient(new TelemetryConfiguration(string.Empty, _telemetryChannel.Object));

            var serviceProvider = new ServiceCollection()
                .AddSingleton(telemetryClient)
                .AddApplicationInsightsTelemetryClientInterfaces()
                .BuildServiceProvider();

            _telemetryClient = serviceProvider.GetService<ITelemetryClient>();
            _telemetryLogger = serviceProvider.GetService<ITelemetryLogger>();
            _traceLogger = serviceProvider.GetService<ITelemetryTraceLogger>();
        }
        
        [Test]
        public void TelemetryClientExtension()
        {
            _telemetryClient.LogSomethingHappenedTrace();
            _telemetryChannel.Verify(x => x.Send(It.Is<TraceTelemetry>(x => x.Message == "Something happened")));
        }
        
        [Test]
        public void TelemetryLoggerExtension()
        {
            _telemetryLogger.Traces.LogSomethingHappenedTrace();
            _telemetryChannel.Verify(x => x.Send(It.Is<TraceTelemetry>(x => x.Message == "Something happened")));
        }
        
        [Test]
        public void TraceLoggerExtension()
        {
            _traceLogger.LogSomethingHappenedTrace();
            _telemetryChannel.Verify(x => x.Send(It.Is<TraceTelemetry>(x => x.Message == "Something happened")));
        }
    }
}