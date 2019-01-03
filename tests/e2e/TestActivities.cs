using Autodesk.Forge.Core.E2eTestHelpers;
using Autodesk.Forge.DesignAutomation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace E2eTests
{
    public partial class Tests
    {
        private readonly Activity act = new Activity()
        {
            CommandLine = new List<string> { "$(engine.path)\\accoreconsole.exe /i $(args[dwg].path) /s $(settings[script].path)" },
            Settings = new Dictionary<string, ISetting>()
            {
                { "script", new StringSetting() { Value = "_test params.json outputs\n" } }
            },
            Appbundles = new List<string>()
            {
                "SdkTester.MyApp+latest"
            },
            Parameters = new Dictionary<string, Parameter>()
            {
                { "dwg", new Parameter() { Verb = Verb.Get } },
                { "params", new Parameter() { Verb = Verb.Read, LocalName = "params.json"} },
                { "results", new Parameter() {Verb = Verb.Post, LocalName = "outputs", Zip = true } }
            },
            Id = "MyAct",
            Engine = "Autodesk.AutoCAD+23"
        };

        [Fact]
        [Order(Weight = 2.0)]
        public async void Activities_Create()
        {
            using (Fixture.StartTestScope())
            {
                await Fixture.DesignAutomationClient.CreateActivityAsync(act, "latest");
            }
        }

        [Fact]
        [Order(Weight = 2.1)]
        public async void Activities_GetAll()
        {
            using (Fixture.StartTestScope())
            {
                var list = await Fixture.DesignAutomationClient.GetAllItems(Fixture.DesignAutomationClient.GetActivitiesAsync);
                Assert.Contains($"{this.nickname}.{this.act.Id}+latest", list);
                Assert.Contains($"{this.nickname}.{this.act.Id}+$LATEST", list);
            }
        }

    }
}
