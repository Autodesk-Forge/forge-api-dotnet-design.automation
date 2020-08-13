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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace E2eTests
{
    public partial class Tests
    {
        [Fact]
        [Order(Weight = 3.0)]
        public async void WorkItems_Create()
        {
            using (var testScope = Fixture.StartTestScope())
            {
                var wi = new WorkItem()
                {
                    ActivityId = $"{this.nickname}.{this.act.Id}+latest",
                    Arguments = new Dictionary<string, IArgument>
                    {
                        { "dwg",  new XrefTreeArgument() { Url = "http://download.autodesk.com/us/samplefiles/acad/blocks_and_tables_-_imperial.dwg" } },
                        { "params", new StringArgument() { Value = "{ 'ExtractBlockNames': true, 'ExtractLayerNames' : true }" }},
                        { "token", new StringArgument("IamToken!")},
                        { "results", new XrefTreeArgument { Verb=Verb.Put, Headers = new Dictionary<string, string>() { { "Content-Type", "binary/octet-stream" } }, Url = "https://dasdev-testing.s3.us-west-2.amazonaws.com/sdktest?X-Amz-Expires=89925&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIZLLKUTZMHO46VTQ/20190103/us-west-2/s3/aws4_request&X-Amz-Date=20190103T025815Z&X-Amz-SignedHeaders=content-type;host&X-Amz-Signature=4bfe24c8855360be63c9c5915deba8750cf7724a532ebfb4fe996872f57d3541" } }
                    }
                };

                var resp = await Fixture.DesignAutomationClient.CreateWorkItemAsync(wi);
                Assert.Equal(Status.Pending, resp.Status);
                while (!resp.Status.IsDone())
                {
                    if (testScope.IsRecording)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                    resp = await Fixture.DesignAutomationClient.GetWorkitemStatusAsync(resp.Id);
                }
                Assert.Equal(Status.Success, resp.Status);
            }
        }

        [Fact]
        [Order(Weight = 3.0)]
        public async void WorkItems_CreateWithStringPayload()
        {
            using (var testScope = Fixture.StartTestScope())
            {
                var activityAlias = $"{this.nickname}.{this.act.Id}+latest";
                var payloadString = string.Format(@"
                {{
                    'activityId' : '{0}',
                    'arguments' : {{
                        'dwg' : {{ 'url' : 'http://download.autodesk.com/us/samplefiles/acad/blocks_and_tables_-_imperial.dwg' }},
                        'params' : {{ 'value' : '{{ \'ExtractBlockNames\': true, \'ExtractLayerNames\' : true }}' }},
                        'token' : 'IamToken!',
                        'results' : 
                        {{ 
                            'url' : 'https://dasdev-testing.s3.us-west-2.amazonaws.com/sdktest?X-Amz-Expires=89925&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIZLLKUTZMHO46VTQ/20190103/us-west-2/s3/aws4_request&X-Amz-Date=20190103T025815Z&X-Amz-SignedHeaders=content-type;host&X-Amz-Signature=4bfe24c8855360be63c9c5915deba8750cf7724a532ebfb4fe996872f57d3541',
                            'verb': 'put',
                            'headers': 
                            {{
                              'Content-Type': 'binary/octet-stream'
                            }}
                        }}
                    }}
                }}", activityAlias);

                var wi = JsonConvert.DeserializeObject<WorkItem>(payloadString);

                var resp = await Fixture.DesignAutomationClient.CreateWorkItemAsync(wi);
                Assert.Equal(Status.Pending, resp.Status);
                while (!resp.Status.IsDone())
                {
                    if (testScope.IsRecording)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                    resp = await Fixture.DesignAutomationClient.GetWorkitemStatusAsync(resp.Id);
                }
                Assert.Equal(Status.Success, resp.Status);
            }
        }

        [Theory]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : { 'bla' : 'http://example.com/test.dwg'},
                    }
                }")]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : {},
                    }
                }")]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : { 'requestConent': 'request body', 'verb' : 'get'},
                    }
                }")]
        [Order(Weight = 3.0)]
        public void DeserializeWorkItem_SerializationException(string json)
        {
            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<WorkItem>(json));
            Assert.Equal("Expected XrefTreeArgument or StringArgument.", ex.Message);
        }

        [Theory]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : [ 'bla' ]
                    }
                }", "StartArray")]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : 101
                    }
                }", "Integer")]
        [InlineData(@"
                {
                    'activityId' : 'SdkTester.MyAct+latest',
                    'arguments' : {
                        'bad' : false
                    }
                }", "Boolean")]
        [Order(Weight = 3.0)]
        public void DeserializeWorkItem_ReaderException(string json, string errorType)
        {
            var ex = Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<WorkItem>(json));
            Assert.Contains(errorType, ex.Message);
        }
    }
}
