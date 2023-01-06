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
using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation.Model;
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

        [Fact]
        [Order(Weight = 1.2)]
        public async void AppBundles_GetAll()
        {
            using (Fixture.StartTestScope())
            {
                var list = await Fixture.DesignAutomationClient.GetAllItems(Fixture.DesignAutomationClient.GetAppBundlesAsync);
                Assert.Contains($"{this.nickname}.{this.app.Id}+latest", list);
                Assert.Contains($"{this.nickname}.{this.app.Id}+rc", list);
                Assert.Contains($"{this.nickname}.{this.app.Id}+beta", list);
                Assert.Contains($"{this.nickname}.{this.app.Id}+$LATEST", list);
                Assert.Distinct(list);
            }
        }

        [Fact]
        [Order(Weight = 1.3)]
        public async void AppBundles_GetAllAlias()
        {
            using (Fixture.StartTestScope())
            {
                var list = await Fixture.DesignAutomationClient.GetAllItems(Fixture.DesignAutomationClient.GetAppBundleAliasesAsync, this.app.Id);
                Assert.Contains(list, e => e.Id == "latest");
                Assert.Contains(list, e => e.Id == "$LATEST");
                Assert.Distinct(list);
            }
        }

        [Fact]
        [Order(Weight = 1.4)]
        public async void AppBundles_GetAllVersion()
        {
            using (Fixture.StartTestScope())
            {
                var list = await Fixture.DesignAutomationClient.GetAllItems(Fixture.DesignAutomationClient.GetAppBundleVersionsAsync, this.app.Id);
                Assert.Contains(1, list);
                Assert.Contains(2, list);
                Assert.Distinct(list);
            }
        }
    }
}
