using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using TomLonghurst.ApplicationInsights.TelemetryLogger.Extensions;

namespace TomLonghurst.ApplicationInsights.TelemetryLogger.UnitTests
{
    public class CustomTelemetryLoggerTests
    {
        private CustomEventAndExceptionTelemetryLogger _telemetryLogger;
        private Mock<ITelemetryChannel> _telemetryChannel;

        [SetUp]
        public void Setup()
        {
            _telemetryChannel = new Mock<ITelemetryChannel>();
            
            var telemetryClient = new TelemetryClient(new TelemetryConfiguration(string.Empty, _telemetryChannel.Object));
            
            _telemetryLogger = ActivatorUtilities.CreateInstance<CustomEventAndExceptionTelemetryLogger>(
                new ServiceCollection()
                    .AddSingleton(telemetryClient)
                    .AddApplicationInsightsTelemetryClientInterfaces()
                    .BuildServiceProvider()
            );
        }

        [Test]
        public void Event()
        {
            _telemetryLogger.TrackEvent("DummyName");
            _telemetryChannel.Verify(x => x.Send(It.Is<EventTelemetry>(x => x.Name == "DummyName")));
        }
        
        [Test]
        public void Event2()
        {
            _telemetryLogger.TrackEvent(new EventTelemetry("DummyName"));
            _telemetryChannel.Verify(x => x.Send(It.Is<EventTelemetry>(x => x.Name == "DummyName")));
        }

        [Test]
        public void Exception()
        {
            _telemetryLogger.TrackException(new PingException("Blah"));
            _telemetryChannel.Verify(x => x.Send(It.Is<ExceptionTelemetry>(
                x => x.Exception.Message == "Blah"
            )));
        }
        
        [Test]
        public void Exception2()
        {
            _telemetryLogger.TrackException(new PingException("Blah"), new Dictionary<string, string> { ["DummyProperty"] = "Blah" });
            _telemetryChannel.Verify(x => x.Send(It.Is<ExceptionTelemetry>(
                x => x.Exception.Message == "Blah"
                && x.Properties.First().Key == "DummyProperty"
                && x.Properties.First().Value == "Blah"
            )));
        }
        
        [Test]
        public void Exception3()
        {
            _telemetryLogger.TrackException(new ExceptionTelemetry(new PingException("Blah")));
            _telemetryChannel.Verify(x => x.Send(It.Is<ExceptionTelemetry>(
                x => x.Exception.Message == "Blah"
            )));
        }
    }
}