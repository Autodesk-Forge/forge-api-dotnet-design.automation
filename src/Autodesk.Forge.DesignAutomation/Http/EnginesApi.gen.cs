/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/forge-ozone/forge-rsdk-codegen)
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
using Autodesk.Forge.DesignAutomation.Model;
using Microsoft.Extensions.Options;

namespace Autodesk.Forge.DesignAutomation.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEnginesApi
    {
        /// <summary>
        /// Gets the details of the specified Engine.
        /// </summary>
        /// <remarks>
        /// Gets the details of the specified Engine. Note that the {id} parameter must be a QualifiedId (owner.name+label).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Full qualified id of the Engine (owner.name+label).</param>
        /// <returns>Task of ApiResponse<Engine></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Engine>> GetEngineAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
        /// <summary>
        /// Lists all available Engines.
        /// </summary>
        /// <remarks>
        /// Lists all available Engines.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of ApiResponse<Page&lt;string&gt;></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Page<string>>> GetEnginesAsync (string page = null, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class EnginesApi : IEnginesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnginesApi"/> class
        /// using ForgeService object
        /// </summary>
        /// <param name="service">An instance of ForgeService</param>
        /// <returns></returns>
        public EnginesApi(ForgeService service = null, IOptions<Configuration> configuration = null)
        {
            this.Service = service ?? ForgeService.CreateDefault();

            // set BaseAddress from configuration or default
            this.Service.Client.BaseAddress = configuration?.Value.BaseAddress ?? new Configuration().BaseAddress;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the ForgeService</value>
        public ForgeService Service {get; set;}

        /// <summary>
        /// Gets the details of the specified Engine.
        /// </summary>
        /// <remarks>
        /// Gets the details of the specified Engine. Note that the {id} parameter must be a QualifiedId (owner.name+label).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Full qualified id of the Engine (owner.name+label).</param>
        /// <returns>Task of ApiResponse<Engine></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Engine>> GetEngineAsync (string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = 
                    Marshalling.BuildRequestUri("/v3/engines/{id}", 
                        routeParameters: new Dictionary<string, object> {
                            { "id", id},
                        },
                        queryParameters: new Dictionary<string, object> {
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers!=null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }


                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse<Engine>(response, default(Engine));
                }

                return new ApiResponse<Engine>(response, await Marshalling.DeserializeAsync<Engine>(response.Content));

            } // using
        }
        /// <summary>
        /// Lists all available Engines.
        /// </summary>
        /// <remarks>
        /// Lists all available Engines.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of ApiResponse<Page&lt;string&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Page<string>>> GetEnginesAsync (string page = null, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = 
                    Marshalling.BuildRequestUri("/v3/engines", 
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: new Dictionary<string, object> {
                            { "page", page},
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers!=null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }


                // tell the underlying pipeline what scope we'd like to use
                if (scopes == null)
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, "code:all");
                }
                else
                {
                    request.Options.Set(ForgeConfiguration.ScopeKey, scopes);
                }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    await response.EnsureSuccessStatusCodeAsync();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse<Page<string>>(response, default(Page<string>));
                }

                return new ApiResponse<Page<string>>(response, await Marshalling.DeserializeAsync<Page<string>>(response.Content));

            } // using
        }
    }
}
