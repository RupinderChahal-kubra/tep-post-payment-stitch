# KUBRA Stitch Function Template

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=iFactor_dotnet-stitchfunction-template&metric=alert_status&token=5958c7c1918d09880ad2916354335c1d71db2ff2)](https://sonarcloud.io/summary/new_code?id=iFactor_dotnet-stitchfunction-template)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=iFactor_dotnet-stitchfunction-template&metric=ncloc&token=5958c7c1918d09880ad2916354335c1d71db2ff2)](https://sonarcloud.io/summary/new_code?id=iFactor_dotnet-stitchfunction-template)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=iFactor_dotnet-stitchfunction-template&metric=coverage&token=5958c7c1918d09880ad2916354335c1d71db2ff2)](https://sonarcloud.io/summary/new_code?id=iFactor_dotnet-stitchfunction-template)

## [Change Log](CHANGELOG.md)

## Other Docs

[.Net Stitch Function Confluence Documentation](https://kubra.jira.com/wiki/spaces/MIC/pages/429817903/Stitch+function+creation+.NET)<br/>
[Kubra.Common.OpenTelemetry](https://github.com/iFactor/common-dotnet/blob/d923ae4781e8aeff10817de30a3a7e3344fe35e6/docs/OpenTelemetry.md#L4)<br/>
[Kubra.Common.Stitch](https://github.com/iFactor/common-dotnet/blob/feature/IXBD-4687-Stitch-Common-Lib/docs/Stitch.md)

## How to run the application locally

### Requirements

- Docker Desktop
- Visual Studio 22+ or VS Code
- .NET 6+

To execute the initialize script, 
- Ensure Docker is running
- open a powershell terminal
- navgiate to the root directory of this solution.
- run the `initializeDev.ps` script with the following command -> `./InitializeDev/InitializeDev.ps1`

Example URL to access the app: http://localhost:8080/balances/132456