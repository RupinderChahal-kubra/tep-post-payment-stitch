using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PactNet;
using PactNet.Output.Xunit;
using PactNet.Verifier;
using Xunit.Abstractions;

namespace Kubra.Pact.Tests.StitchPacts
{
    public class StitchApiTests : IClassFixture<TestStitchBalanceFixture>
    {
        private TestStitchBalanceFixture _apiFixture;
        private ITestOutputHelper _output;
        public StitchApiTests(ITestOutputHelper output, TestStitchBalanceFixture apiFixture)
        {
            _apiFixture = apiFixture;
            _output = output;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void EnsureExternalApiHonoursPactWithConsumer(string pactPath)
        {
            // Arrange
            var config = new PactVerifierConfig
            {
                LogLevel = PactLogLevel.Debug,
                Outputters = new[]
                {
                    new XunitOutput(_output)
                }
            };

            // Act / Assert
            using var pactVerifier = new PactVerifier("Test Balance API", config);
            pactVerifier
                .WithHttpEndpoint(_apiFixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithRequestTimeout(TimeSpan.FromMinutes(1))
                .Verify();
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                //Select the appropriate contract for your implementation. CircleCi will have to be updated to match.
                new object[] { Environment.GetEnvironmentVariable("PACT_CONTRACT_FOLDER") ?? "Pacts/External Balance API Consumer-External Balance API.json" },
                //new object[] { Environment.GetEnvironmentVariable("PACT_CONTRACT_FOLDER") ?? "Pacts/Payment Posting Consumer-Payment Posting Provider.json" }
            };
    }
    public class TestStitchBalanceFixture : IDisposable
    {
        private readonly IHost server;
        public Uri ServerUri { get; }

        public TestStitchBalanceFixture()
        {
            ServerUri = new Uri("http://localhost:9225");
            server = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(ServerUri.ToString());
                    webBuilder.UseStartup<StitchTestStartup>();
                })
                .Build();
            server.Start();
        }

        public void Dispose()
        {
            server.Dispose();
        }
    }
}

