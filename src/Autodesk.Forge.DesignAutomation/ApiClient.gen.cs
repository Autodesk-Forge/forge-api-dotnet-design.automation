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
using Microsoft.Extensions.Options;
using Autodesk.Forge.DesignAutomation.Http;
using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.DesignAutomation
{
    public partial class DesignAutomationClient
    {
        public IActivitiesApi ActivitiesApi { get; }
        public IAppBundlesApi AppBundlesApi { get; }
        public IEnginesApi EnginesApi { get; }
        public IForgeAppsApi ForgeAppsApi { get; }
        public IHealthApi HealthApi { get; }
        public ISharesApi SharesApi { get; }
        public IWorkItemsApi WorkItemsApi { get; }

        /// <summary>
        /// Gets or sets the ForgeService object
        /// </summary>
        /// <value>An instance of the ForgeService</value>
        public ForgeService Service { get; set; }

        /// <summary>
        /// Gets the configuration object.
        /// </summary>
        public Configuration Configuration { get; }

        public DesignAutomationClient(ForgeService service = null, IOptions<Configuration> configuration = null, IActivitiesApi activitiesApi = null, IAppBundlesApi appBundlesApi = null, IEnginesApi enginesApi = null, IForgeAppsApi forgeAppsApi = null, IHealthApi healthApi = null, ISharesApi sharesApi = null, IWorkItemsApi workItemsApi = null)
        {
            this.Configuration = configuration?.Value ?? new Configuration();

            this.Service = service ?? ForgeService.CreateDefault();

            // set BaseAddress from configuration
            this.Service.Client.BaseAddress = Configuration.BaseAddress;

            this.ActivitiesApi = activitiesApi ?? new ActivitiesApi(service, configuration);
            this.AppBundlesApi = appBundlesApi ?? new AppBundlesApi(service, configuration);
            this.EnginesApi = enginesApi ?? new EnginesApi(service, configuration);
            this.ForgeAppsApi = forgeAppsApi ?? new ForgeAppsApi(service, configuration);
            this.HealthApi = healthApi ?? new HealthApi(service, configuration);
            this.SharesApi = sharesApi ?? new SharesApi(service, configuration);
            this.WorkItemsApi = workItemsApi ?? new WorkItemsApi(service, configuration);
        }

        /// <summary>
        /// Creates a new Activity. Creates a new Activity.              Limits (varies by Engine):              1. Number of Activities that can be created.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="item"></param>
        /// <returns>Task of Activity</returns>
        public async System.Threading.Tasks.Task<Activity> CreateActivityAsync (Activity item)
        {
             var response = await this.ActivitiesApi.CreateActivityAsync(item);
             return response.Content;

        }
        /// <summary>
        /// Creates a new alias for this Activity. Creates a new alias for this Activity.              Limit:              1. Number of aliases (LimitAliases).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="alias">{ id : {anyname}, version : {version number}, receiver : [{id of other Forge app},...] }.</param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> CreateActivityAliasAsync (string id, Alias alias)
        {
             var response = await this.ActivitiesApi.CreateActivityAliasAsync(id, alias);
             return response.Content;

        }
        /// <summary>
        /// Creates a new version of the Activity. Creates a new version of the Activity.              Limit:              1. Number of versions (LimitVersions).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="item"></param>
        /// <returns>Task of Activity</returns>
        public async System.Threading.Tasks.Task<Activity> CreateActivityVersionAsync (string id, Activity item)
        {
             var response = await this.ActivitiesApi.CreateActivityVersionAsync(id, item);
             return response.Content;

        }
        /// <summary>
        /// Deletes the specified Activity. Deletes the specified Activity, including all versions and aliases.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteActivityAsync (string id)
        {
             await this.ActivitiesApi.DeleteActivityAsync(id);

        }
        /// <summary>
        /// Deletes the alias. Deletes the alias.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="aliasId">Name of alias to delete.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteActivityAliasAsync (string id, string aliasId)
        {
             await this.ActivitiesApi.DeleteActivityAliasAsync(id, aliasId);

        }
        /// <summary>
        /// Deletes the specified version of the Activity. Deletes the specified version of the Activity.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="version">Version to delete (integer).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteActivityVersionAsync (string id, int version)
        {
             await this.ActivitiesApi.DeleteActivityVersionAsync(id, version);

        }
        /// <summary>
        /// Gets the details of the specified version of the Activity. Gets the details of the specified version of the Activity.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="version">Version to retrieve (integer).</param>
        /// <returns>Task of Activity</returns>
        public async System.Threading.Tasks.Task<Activity> GeActivityVersionAsync (string id, int version)
        {
             var response = await this.ActivitiesApi.GeActivityVersionAsync(id, version);
             return response.Content;

        }
        /// <summary>
        /// Lists all available Activities. Lists all available Activities, including Activities shared with this Forge app.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<Page<string>> GetActivitiesAsync (string page = null)
        {
             var response = await this.ActivitiesApi.GetActivitiesAsync(page);
             return response.Content;

        }
        /// <summary>
        /// Gets the details of the specified Activity. Gets the details of the specified Activity. Note that the {id} parameter must be a QualifiedId (owner.name+label).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Full qualified id of the Activity (owner.name+label).</param>
        /// <returns>Task of Activity</returns>
        public async System.Threading.Tasks.Task<Activity> GetActivityAsync (string id)
        {
             var response = await this.ActivitiesApi.GetActivityAsync(id);
             return response.Content;

        }
        /// <summary>
        /// Get alias details. Get alias details.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="aliasId">Name of alias.</param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> GetActivityAliasAsync (string id, string aliasId)
        {
             var response = await this.ActivitiesApi.GetActivityAliasAsync(id, aliasId);
             return response.Content;

        }
        /// <summary>
        /// Lists all aliases for the specified Activity. Lists all aliases for the specified Activity.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;Alias&gt;</returns>
        public async System.Threading.Tasks.Task<Page<Alias>> GetActivityAliasesAsync (string id, string page = null)
        {
             var response = await this.ActivitiesApi.GetActivityAliasesAsync(id, page);
             return response.Content;

        }
        /// <summary>
        /// Lists all versions of the specified Activity. Lists all versions of the specified Activity.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;int&gt;</returns>
        public async System.Threading.Tasks.Task<Page<int>> GetActivityVersionsAsync (string id, string page = null)
        {
             var response = await this.ActivitiesApi.GetActivityVersionsAsync(id, page);
             return response.Content;

        }
        /// <summary>
        /// Modify alias details. Modify alias details.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of Activity (unqualified).</param>
        /// <param name="aliasId">Name of alias.</param>
        /// <param name="alias">Alias details to be modified.</param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> ModifyActivityAliasAsync (string id, string aliasId, AliasPatch alias)
        {
             var response = await this.ActivitiesApi.ModifyActivityAliasAsync(id, aliasId, alias);
             return response.Content;

        }
        /// <summary>
        /// Creates a new AppBundle. Creates a new AppBundle.              | Limits: (varies by Engine)              | 1. Number of AppBundle that can be created.              | 2. Size of AppBundle.              | This method creates new AppBundle returned in response value.              | POST upload is required to limit upload size.              |              | After this request, you need to upload the AppBundle zip.              | To upload the AppBundle package, create a multipart/form-data request using data received in reponse uploadParameters:              | - endpointURL is the URL to make the upload package request against,              | - formData are the parameters that need to be put into the upload package request body.              |   They must be followed by an extra &#39;file&#39; parameter indicating the location of the package file.              | An example:              |              | curl https://bucketname.s3.amazonaws.com/              | -F key &#x3D; apps/myApp/myfile.zip              | -F content-type &#x3D; application/octet-stream              | -F policy &#x3D; eyJleHBpcmF0aW9uIjoiMjAxOC0wNi0yMVQxMzo...(trimmed)              | -F x-amz-signature &#x3D; 800e52d73579387757e1c1cd88762...(trimmed)              | -F x-amz-credential &#x3D; AKIAIOSFODNN7EXAMPLE/20180621/us-west-2/s3/aws4_request/              | -F x-amz-algorithm &#x3D; AWS4-HMAC-SHA256              | -F x-amz-date &#x3D; 20180621T091656Z              | -F file&#x3D;@E:\\myfile.zip              | The &#39;file&#39; field must be at the end, all fields after &#39;file&#39; will be ignored.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="item"></param>
        /// <returns>Task of AppBundle</returns>
        public async System.Threading.Tasks.Task<AppBundle> CreateAppBundleAsync (AppBundle item)
        {
             var response = await this.AppBundlesApi.CreateAppBundleAsync(item);
             return response.Content;

        }
        /// <summary>
        /// Creates a new alias for this AppBundle. Creates a new alias for this AppBundle. Limit: 1. Number of aliases (LimitAliases).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="alias"></param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> CreateAppBundleAliasAsync (string id, Alias alias)
        {
             var response = await this.AppBundlesApi.CreateAppBundleAliasAsync(id, alias);
             return response.Content;

        }
        /// <summary>
        /// Creates a new version of the AppBundle. Creates a new version of the AppBundle.              | Limit:              | 1. Number of versions (LimitVersions).              | 2. Size of AppBundle.              | This method creates new AppBundle returned in response value.              | POST upload is required to limit upload size. The endpoint url and all form fields are retrieved in AppBundle.UploadParameters.              |              | After this request, you need to upload the AppBundle zip.              | Use data received in the response to create multipart/form-data request. An example:              |              | curl https://bucketname.s3.amazonaws.com/              | -F key &#x3D; apps/myApp/myfile.zip              | -F content-type &#x3D; application/octet-stream              | -F policy &#x3D; eyJleHBpcmF0aW9uIjoiMjAxOC0wNi0yMVQxMzo...(trimmed)              | -F x-amz-signature &#x3D; 800e52d73579387757e1c1cd88762...(trimmed)              | -F x-amz-credential &#x3D; AKIAIOSFODNN7EXAMPLE/20180621/us-west-2/s3/aws4_request/              | -F x-amz-algorithm &#x3D; AWS4-HMAC-SHA256              | -F x-amz-date &#x3D; 20180621T091656Z              | -F file&#x3D;@E:\\myfile.zip              The &#39;file&#39; field must be at the end, all fields after &#39;file&#39; will be ignored.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of app (unqualified).</param>
        /// <param name="item"></param>
        /// <returns>Task of AppBundle</returns>
        public async System.Threading.Tasks.Task<AppBundle> CreateAppBundleVersionAsync (string id, AppBundle item)
        {
             var response = await this.AppBundlesApi.CreateAppBundleVersionAsync(id, item);
             return response.Content;

        }
        /// <summary>
        /// Deletes the specified AppBundle. Deletes the specified AppBundle, including all versions and aliases.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteAppBundleAsync (string id)
        {
             await this.AppBundlesApi.DeleteAppBundleAsync(id);

        }
        /// <summary>
        /// Deletes the alias. Deletes the alias.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="aliasId">Name of alias to delete.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteAppBundleAliasAsync (string id, string aliasId)
        {
             await this.AppBundlesApi.DeleteAppBundleAliasAsync(id, aliasId);

        }
        /// <summary>
        /// Deletes the specified version of the AppBundle. Deletes the specified version of the AppBundle.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="version">Version to delete (as integer).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteAppBundleVersionAsync (string id, int version)
        {
             await this.AppBundlesApi.DeleteAppBundleVersionAsync(id, version);

        }
        /// <summary>
        /// Gets the details of the specified AppBundle. Gets the details of the specified AppBundle. Note that the {id} parameter must be a QualifiedId (owner.name+label).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Full qualified id of the AppBundle (owner.name+label).</param>
        /// <returns>Task of AppBundle</returns>
        public async System.Threading.Tasks.Task<AppBundle> GetAppBundleAsync (string id)
        {
             var response = await this.AppBundlesApi.GetAppBundleAsync(id);
             return response.Content;

        }
        /// <summary>
        /// Get alias details. Get alias details.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="aliasId">Name of alias.</param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> GetAppBundleAliasAsync (string id, string aliasId)
        {
             var response = await this.AppBundlesApi.GetAppBundleAliasAsync(id, aliasId);
             return response.Content;

        }
        /// <summary>
        /// Lists all aliases for the specified AppBundle. Lists all aliases for the specified AppBundle.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of activity (unqualified).</param>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;Alias&gt;</returns>
        public async System.Threading.Tasks.Task<Page<Alias>> GetAppBundleAliasesAsync (string id, string page = null)
        {
             var response = await this.AppBundlesApi.GetAppBundleAliasesAsync(id, page);
             return response.Content;

        }
        /// <summary>
        /// Gets the details of the specified version of the AppBundle. Gets the details of the specified version of the AppBundle.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="version">Version to retrieve (as integer).</param>
        /// <returns>Task of AppBundle</returns>
        public async System.Threading.Tasks.Task<AppBundle> GetAppBundleVersionAsync (string id, int version)
        {
             var response = await this.AppBundlesApi.GetAppBundleVersionAsync(id, version);
             return response.Content;

        }
        /// <summary>
        /// Lists all versions of the specified AppBundle. Lists all versions of the specified AppBundle.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;int&gt;</returns>
        public async System.Threading.Tasks.Task<Page<int>> GetAppBundleVersionsAsync (string id, string page = null)
        {
             var response = await this.AppBundlesApi.GetAppBundleVersionsAsync(id, page);
             return response.Content;

        }
        /// <summary>
        /// Lists all available AppBundles. Lists all available AppBundles, including AppBundles shared with this Forge app.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<Page<string>> GetAppBundlesAsync (string page = null)
        {
             var response = await this.AppBundlesApi.GetAppBundlesAsync(page);
             return response.Content;

        }
        /// <summary>
        /// Modify alias details. Modify alias details.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Name of AppBundle (unqualified).</param>
        /// <param name="aliasId">Name of alias.</param>
        /// <param name="alias">Alias details to be modified.</param>
        /// <returns>Task of Alias</returns>
        public async System.Threading.Tasks.Task<Alias> ModifyAppBundleAliasAsync (string id, string aliasId, AliasPatch alias)
        {
             var response = await this.AppBundlesApi.ModifyAppBundleAliasAsync(id, aliasId, alias);
             return response.Content;

        }
        /// <summary>
        /// Gets the details of the specified Engine. Gets the details of the specified Engine. Note that the {id} parameter must be a QualifiedId (owner.name+label).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Full qualified id of the Engine (owner.name+label).</param>
        /// <returns>Task of Engine</returns>
        public async System.Threading.Tasks.Task<Engine> GetEngineAsync (string id)
        {
             var response = await this.EnginesApi.GetEngineAsync(id);
             return response.Content;

        }
        /// <summary>
        /// Lists all available Engines. Lists all available Engines.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Access an additional &#39;page&#39; of data when necessary, based on the &#39;paginationToken&#39; returned from a previous invocation. (optional)</param>
        /// <returns>Task of Page&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<Page<string>> GetEnginesAsync (string page = null)
        {
             var response = await this.EnginesApi.GetEnginesAsync(page);
             return response.Content;

        }
        /// <summary>
        /// Creates/updates the nickname for the current Forge app. Creates/updates the nickname for the current Forge app.  The nickname is  used as a clearer alternative name when identifying AppBundles and Activities, as  compared to using the Forge app ID.  Once you have defined a nickname,  it MUST be used instead of the Forge app ID.                The new nickname cannot be in use by any other Forge app.                The Forge app cannot have any data when this endpoint is invoked.  Use the &#39;DELETE /forgeapps/me&#39;  endpoint (cautiously!!!) to remove all data from this Forge app.  &#39;DELETE /forgeapps/me&#39; is  also the only way to remove the nickname.                Note the nickname is supplied in the body, not as a query-parameter.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        /// <param name="nicknameRecord">new nickname (public key is for internal use only).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CreateNicknameAsync (string id, NicknameRecord nicknameRecord)
        {
             await this.ForgeAppsApi.CreateNicknameAsync(id, nicknameRecord);

        }
        /// <summary>
        /// Delete all data associated with this Forge app. Delete all data associated with the given Forge app.                ALL Design Automation appbundles and activities are DELETED.                This action is required prior to using the &#39;PATCH /forgeapps/me&#39; endpoint when changing the nickname for the current Forge app,.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteForgeAppAsync (string id)
        {
             await this.ForgeAppsApi.DeleteForgeAppAsync(id);

        }
        /// <summary>
        /// Returns the user&#39;s (app) nickname. Return the given Forge app&#39;s nickname.                If the app has no nickname, this route will return its id.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id">Must be \&quot;me\&quot; for the call to succeed.</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> GetNicknameAsync (string id)
        {
             var response = await this.ForgeAppsApi.GetNicknameAsync(id);
             return response.Content;

        }
        /// <summary>
        ///  Gets the health status by Engine or for all Engines (Inventor, AutoCAD ...).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="engine"></param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> HealthStatusAsync (string engine)
        {
             var response = await this.HealthApi.HealthStatusAsync(engine);
             return response.Content;

        }
        /// <summary>
        /// Gets all Shares (AppBundles and Activities) shared by this Forge app. Gets all Shares (AppBundles and Activities) shared by this Forge app (shared to other  Forge apps for them to use).                Sharing of AppBundles and Activities is controlled via the use of &#39;aliases&#39;.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="page">Used to get subsequent &#39;pages&#39; of data. (optional)</param>
        /// <returns>Task of Page&lt;Share&gt;</returns>
        public async System.Threading.Tasks.Task<Page<Share>> GetSharesAsync (string page = null)
        {
             var response = await this.SharesApi.GetSharesAsync(page);
             return response.Content;

        }
        /// <summary>
        /// Creates a new WorkItem and queues it for processing. Creates a new WorkItem and queues it for processing.  The new WorkItem is always placed on the  queue; no further action is necessary.                Limits (Engine-specific):                1. Number of downloads (LimitDownloads)  2. Number of uploads (LimitUploads)  3. Total download size (LimitDownloadSize)  4. Total upload size (LimitUploadSize)  5. Processing time (LimitProcessingTime)  6. Total size of uncompressed bits for all referenced appbundles (LimitTotalUncompressedAppsSizePerActivity).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="workitem"></param>
        /// <returns>Task of WorkItemStatus</returns>
        public async System.Threading.Tasks.Task<WorkItemStatus> CreateWorkItemsAsync (WorkItem workitem)
        {
             var response = await this.WorkItemsApi.CreateWorkItemsAsync(workitem);
             return response.Content;

        }
        /// <summary>
        /// Cancels a specific WorkItem. Cancels a specific WorkItem.  If the WorkItem is on the queue, it is removed from the queue and not processed.  If the WorkItem is already being processed, then it may or may not be interrupted and cancelled.  If the WorkItem has already finished processing, then it has no effect on the processing or results.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteWorkitemAsync (string id)
        {
             await this.WorkItemsApi.DeleteWorkitemAsync(id);

        }
        /// <summary>
        /// Gets the status of a specific WorkItem. Gets the status of a specific WorkItem.  Typically used to &#39;poll&#39; for              the completion of a WorkItem, but see the use of the &#39;onComplete&#39; argument for              an alternative that does not require &#39;polling&#39;.  WorkItem status is retained              for a limited period of time after the WorkItem completes.              Limits:              1. Retention period (LimitWorkItemRetentionPeriod).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of WorkItemStatus</returns>
        public async System.Threading.Tasks.Task<WorkItemStatus> GetWorkitemStatusAsync (string id)
        {
             var response = await this.WorkItemsApi.GetWorkitemStatusAsync(id);
             return response.Content;

        }
    }
}
