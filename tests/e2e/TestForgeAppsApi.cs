using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation.Model;
using System;
using Xunit;

namespace E2eTests
{
    [Collection("E2e Test Fixture")]
    public class TestForgeAppsApi
    {
        private readonly Fixture Fixture;

        public TestForgeAppsApi(Fixture fixture)
        {
            this.Fixture = fixture;
        }
        [Fact]
        [Order(Weight = 0.0)]
        public async void TestDelete()
        {
            using (Fixture.StartTestScope())
            {
                await this.Fixture.DesignAutomationClient.DeleteUserAsync("me");
            }
        }

        [Fact]
        [Order(Weight = 0.1)]
        public async void TestCreateNickname()
        {
            using (Fixture.StartTestScope())
            {
                await this.Fixture.DesignAutomationClient.CreateNicknameAsync("me", new NicknameRecord { Nickname = "SdkTester" });
            }
        }

        [Fact]
        [Order(Weight = 0.2)]
        public async void TestGetNickname()
        {
            using (Fixture.StartTestScope())
            {
                var resp = await this.Fixture.DesignAutomationClient.GetNicknameAsync("me");
                Assert.Equal("SdkTester", resp);
            }
        }
    }
}
