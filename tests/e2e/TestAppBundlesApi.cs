using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation.Model;
using System;
using System.IO;
using Xunit;

namespace E2eTests
{
    public partial class Tests
    {
        private readonly AppBundle app = new AppBundle()
        {
            Id = "MyApp",
            Engine = "Autodesk.AutoCAD+23",
        };

        [Fact]
        [Order(Weight = 1.0)]
        public async void AppBundles_Create()
        {
            using (Fixture.StartTestScope())
            {
                // create an app and label it as "beta"
                await Fixture.DesignAutomationClient.CreateAppBundleAsync(this.app, "beta", Path.Combine(this.Fixture.DataFolder, "beta.zip"));
            }
        }

        [Fact]
        [Order(Weight = 1.1)]
        public async void AppBundles_Update()
        {
            using (Fixture.StartTestScope())
            {
                // later upload a new version and label it as "rc" (note that "beta" is still available and addressable)
                var version = await Fixture.DesignAutomationClient.UpdateAppBundleAsync(this.app, "rc", Path.Combine(this.Fixture.DataFolder, "releaseCandidate.zip"));

                // finally create a "latest" label that points to the same version as "rc"
                await Fixture.DesignAutomationClient.CreateAppBundleAliasAsync(this.app.Id, new Alias { Id = "latest", Version = version });
            }
        }
    }
}
