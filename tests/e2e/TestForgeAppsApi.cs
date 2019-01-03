using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation.Model;
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
