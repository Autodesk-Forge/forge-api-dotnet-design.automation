using Autodesk.Forge.Core;
using Autodesk.Forge.DesignAutomation.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Autodesk.Forge.DesignAutomation.Http
{
    public partial interface IForgeAppsApi
    {
        public System.Threading.Tasks.Task<ApiResponse<NicknameRecord>> GetNicknameRecordAsync(string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true);
    }
    public partial class ForgeAppsApi
    {
        /// <summary>
        /// Returns the app's nickname.
        /// </summary>
        /// <remarks>
        /// Return the given Forge app's nickname.
        /// If the app has no nickname, this route will return its id.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be "me" for the call to succeed.</param>
        /// <returns>Task of ApiResponse<string></returns>

        public async System.Threading.Tasks.Task<ApiResponse<string>> GetNicknameAsync(string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            var nr = await GetNicknameRecordAsync(id);
            return new ApiResponse<string>(nr.HttpResponse, nr.Content.Nickname);
        }
        /// <summary>
        /// Returns the app's nickname and optional public key.
        /// </summary>
        /// <remarks>
        /// Return the given Forge app's nickname and public key if one has been uploaded
        /// If the app has no nickname, this route will return its id.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be "me" for the call to succeed.</param>
        /// <returns>Task of ApiResponse<string></returns>
        public async System.Threading.Tasks.Task<ApiResponse<NicknameRecord>> GetNicknameRecordAsync(string id, string scopes = null, IDictionary<string, string> headers = null, bool throwOnError = true)
        {
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri =
                    Marshalling.BuildRequestUri("/v3/forgeapps/{id}",
                        routeParameters: new Dictionary<string, object> {
                            { "id", id},
                        },
                        queryParameters: new Dictionary<string, object>
                        {
                        }
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                if (headers != null)
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
                    return new ApiResponse<NicknameRecord>(response, default(NicknameRecord));
                }
                // response.Content is either simply a nickname or a JSON of the form {nickname:<nickname>, publicKey:<publicKey>}. We must handle both.
                var str = await response.Content.ReadAsStringAsync();
                str = str.Trim();
                if (str.StartsWith("{"))
                {
                    return new ApiResponse<NicknameRecord>(response, JsonConvert.DeserializeObject<NicknameRecord>(str));
                }
                else
                {
                    var nickname = JsonConvert.DeserializeObject<string>(str);
                    return new ApiResponse<NicknameRecord>(response, new NicknameRecord() { Nickname = nickname });
                }
            } // using
        }
    }
}
