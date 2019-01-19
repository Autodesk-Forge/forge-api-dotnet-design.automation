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
using Autodesk.Forge.DesignAutomation.Rsdk.Model;
using System;
using Xunit;

namespace E2eTests
{
    public partial class Tests
    {
        private readonly string nickname = "SdkTester";

        [Fact]
        [Order(Weight = 0.0)]
        public async void ForgeApps_Delete()
        {
            using (Fixture.StartTestScope())
            {
                await this.Fixture.DesignAutomationClient.DeleteUserAsync("me");
            }
        }

        [Fact]
        [Order(Weight = 0.1)]
        public async void ForgeApps_CreateNickname()
        {
            using (Fixture.StartTestScope())
            {
                await this.Fixture.DesignAutomationClient.CreateNicknameAsync("me", new NicknameRecord { Nickname = this.nickname });
            }
        }

        [Fact]
        [Order(Weight = 0.2)]
        public async void ForgeApps_GetNickname()
        {
            using (Fixture.StartTestScope())
            {
                var resp = await this.Fixture.DesignAutomationClient.GetNicknameAsync("me");
                Assert.Equal(this.nickname, resp);
            }
        }
    }
}
