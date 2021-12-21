using System;
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
    public class TelemetryLoggerTests
    {
        private TelemetryLogger _telemetryLogger;
        private Mock<ITelemetryChannel> _telemetryChannel;
        private TelemetryClient _telemetryClient;

        [SetUp]
        public void Setup()
        {
            _telemetryChannel = new Mock<ITelemetryChannel>();
            _telemetryClient = new TelemetryClient(new TelemetryConfiguration(string.Empty, _telemetryChannel.Object));
            
            _telemetryLogger = ActivatorUtilities.CreateInstance<TelemetryLogger>(
                new ServiceCollection()
                    .AddSingleton(_telemetryClient)
                    .AddApplicationInsightsTelemetryLogger()
                    .BuildServiceProvider()
            );
        }

        [Test]
        public void Event()
        {
            _telemetryLogger.Events.TrackEvent("DummyName");
            _telemetryChannel.Verify(x => x.Send(It.Is<EventTelemetry>(x => x.Name == "DummyName")));
        }
        
        [Test]
        public void Event2()
        {
            _telemetryLogger.Events.TrackEvent(new EventTelemetry("DummyName"));
            _telemetryChannel.Verify(x => x.Send(It.Is<EventTelemetry>(x => x.Name == "DummyName")));
        }
        
        [Test]
        public void Request()
        {
            _telemetryLogger.Requests.TrackRequest("DummyName", DateTimeOffset.FromUnixTimeSeconds(500), TimeSpan.FromSeconds(1), "200", true);
            _telemetryChannel.Verify(x => x.Send(It.Is<RequestTelemetry>(
                x => x.Name == "DummyName"
                     && x.Timestamp == DateTimeOffset.FromUnixTimeSeconds(500)
                     && x.Duration == TimeSpan.FromSeconds(1)
                     && x.ResponseCode == "200"
                     && x.Success == true
            )));
        }
        
        [Test]
        public void Request2()
        {
            _telemetryLogger.Requests.TrackRequest(new RequestTelemetry("DummyName", DateTimeOffset.FromUnixTimeSeconds(500), TimeSpan.FromSeconds(1), "200", true));
            _telemetryChannel.Verify(x => x.Send(It.Is<RequestTelemetry>(
                x => x.Name == "DummyName"
                     && x.Timestamp == DateTimeOffset.FromUnixTimeSeconds(500)
                     && x.Duration == TimeSpan.FromSeconds(1)
                     && x.ResponseCode == "200"
                     && x.Success == true
            )));
        }
        
        [Test]
        public void Dependency()
        {
            _telemetryLogger.Dependencies.TrackDependency("DummyType", "DummyName", "DummyData", DateTimeOffset.FromUnixTimeSeconds(500), TimeSpan.FromSeconds(1), true);
            _telemetryChannel.Verify(x => x.Send(It.Is<DependencyTelemetry>(
                x => x.Name == "DummyName"
                     && x.Type == "DummyType"
                     && x.Data == "DummyData"
                     && x.Timestamp == DateTimeOffset.FromUnixTimeSeconds(500)
                     && x.Duration == TimeSpan.FromSeconds(1)
                     && x.Success == true
            )));
        }
        
        [Test]
        public void Dependency2()
        {
            _telemetryLogger.Dependencies.TrackDependency("DummyType", "DummyTarget", "DummyName", "DummyData", DateTimeOffset.FromUnixTimeSeconds(500), TimeSpan.FromSeconds(1), "200", true);
            _telemetryChannel.Verify(x => x.Send(It.Is<DependencyTelemetry>(
                x => x.Name == "DummyName"
                     && x.Target == "DummyTarget"
                     && x.Type == "DummyType"
                     && x.Data == "DummyData"
                     && x.Timestamp == DateTimeOffset.FromUnixTimeSeconds(500)
                     && x.Duration == TimeSpan.FromSeconds(1)
                     && x.ResultCode == "200"
                     && x.Success == true
            )));
        }
        
        [Test]
        public void Dependency3()
        {
            _telemetryLogger.Dependencies.TrackDependency(new DependencyTelemetry("DummyType", "DummyTarget", "DummyName", "DummyData"));
            _telemetryChannel.Verify(x => x.Send(It.Is<DependencyTelemetry>(
                x => x.Name == "DummyName"
                     && x.Target == "DummyTarget"
                     && x.Type == "DummyType"
                     && x.Data == "DummyData"
            )));
        }
        
        [Test]
        public void Dependency4()
        {
            _telemetryLogger.Dependencies.TrackDependency(new DependencyTelemetry("DummyType", "DummyTarget", "DummyName", "DummyData", DateTimeOffset.FromUnixTimeSeconds(500), TimeSpan.FromSeconds(1), "200", true));
            _telemetryChannel.Verify(x => x.Send(It.Is<DependencyTelemetry>(
                x => x.Name == "DummyName"
                     && x.Target == "DummyTarget"
                     && x.Type == "DummyType"
                     && x.Data == "DummyData"
                     && x.Timestamp == DateTimeOffset.FromUnixTimeSeconds(500)
                     && x.Duration == TimeSpan.FromSeconds(1)
                     && x.ResultCode == "200"
                     && x.Success == true
            )));
        }
    }
}