/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Design Automation
 *
  * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Autodesk.Forge.Core;
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
                .AddForgeAlternativeEnvironmentVariables()
                .Build();

            DataFolder = Path.Combine(Environment.CurrentDirectory, "../../../data/");
            this.testHandler = new TestHandler(Path.Combine(Environment.CurrentDirectory, "../../../recordings/"));
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
