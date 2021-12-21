@echo off
set /p version="Enter Version Number to Build With: "

@echo on
dotnet pack ".\TomLonghurst.ApplicationInsights.TelemetryLogger\TomLonghurst.ApplicationInsights.TelemetryLogger.csproj"  --configuration Release /p:Version=%version%

pause