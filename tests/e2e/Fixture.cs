using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Xunit;

namespace E2eTests
{
    public class Fixture
    {
        public readonly DesignAutomationClient DesignAutomationClient;
        private TestHandler testHandler;

        public Fixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.user.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            DataFolder = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\data\\");
            this.testHandler = new TestHandler(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\recordings\\"));
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDesignAutomation(configuration).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return this.testHandler;
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            this.DesignAutomationClient = serviceProvider.GetRequiredService<DesignAutomationClient>();
        }

        public ITestScope StartTestScope([CallerMemberName] string name = null)
        {
            return this.testHandler.StartTestScope(name);
        }

        public string DataFolder { get; set; }
    }
    [CollectionDefinition(nameof(E2eTests))]
    [TestCaseOrderer("Autodesk.Forge.Core.E2eTestHelpers.TestOrderer", "Autodesk.Forge.Core.E2eTestHelpers")]
    public class E2eTests : ICollectionFixture<Fixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] attribute
    }

    [Collection(nameof(E2eTests))]
    public partial class Tests 
    {
        private readonly Fixture Fixture;

        public Tests(Fixture fixture)
        {
            this.Fixture = fixture;
        }
    }
}
