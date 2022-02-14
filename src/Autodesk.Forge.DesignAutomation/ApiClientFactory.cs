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
using Autodesk.Forge.DesignAutomation.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace Autodesk.Forge.DesignAutomation
{
    public class DesignAutomationClientFactory
    {
        IServiceProvider services;
        public DesignAutomationClientFactory(IServiceProvider services)
        {
            this.services = services;
        }
        public DesignAutomationClient CreateClient(string agent = null)
        {
            var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
            var typedClientFactory = services.GetRequiredService<ITypedHttpClientFactory<ForgeService>>();
            var client = httpClientFactory.CreateClient(agent?? ForgeAgentHandler.defaultAgentName);
            var forgeService = typedClientFactory.CreateClient(client);
            var designAutomationlient = ActivatorUtilities.CreateInstance<DesignAutomationClient>(
                services, 
                forgeService,
                ActivatorUtilities.CreateInstance<ActivitiesApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<AppBundlesApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<EnginesApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<ForgeAppsApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<HealthApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<ServiceLimitsApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<SharesApi>(services, forgeService),
                ActivatorUtilities.CreateInstance<WorkItemsApi>(services, forgeService));
            designAutomationlient.Agent = agent;
            return designAutomationlient;
        }
    }
}
