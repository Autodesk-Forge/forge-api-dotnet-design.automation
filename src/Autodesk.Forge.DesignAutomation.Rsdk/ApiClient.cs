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
using Autodesk.Forge.DesignAutomation.Rsdk.Model;
using Autodesk.Forge.DesignAutomation.Rsdk.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System;
using Autodesk.Forge.Core;

namespace Autodesk.Forge.DesignAutomation.Rsdk
{
    public partial class DesignAutomationClient
    {

        public async Task UploadAppBundleBits(UploadAppBundleParameters uploadParameters, string packagePath)
        {
            using (var formData = new MultipartFormDataContent())
            { 
                foreach (var kv in uploadParameters.FormData)
                {
                    if (kv.Value != null)
                    {
                        formData.Add(new StringContent(kv.Value), kv.Key);
                    }
                }

                using (var content = new StreamContent(new FileStream(packagePath, FileMode.Open)))
                {
                    formData.Add(content, "file");
                    var response = await Service.Client.PostAsync(uploadParameters.EndpointURL, formData);
                    response.EnsureSuccessStatusCode();
                }
            }
        }
        /// <summary>
        /// Creates a new AppBundle from the metadata in <paramref name="app"/> and the code in <paramref name="packagePath"/>
        /// and labels with with <paramref name="label"/>.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="label"></param>
        /// <param name="packagePath"></param>
        /// <returns></returns>
        public async Task CreateAppBundleAsync(AppBundle app, string label, string packagePath)
        {
            var item = await this.CreateAppBundleAsync(app);

            await UploadAppBundleBits(item.UploadParameters, packagePath);

            await this.CreateAppBundleAliasAsync(app.Id, new Alias() { Id = label, Version = item.Version });
        }

        public async Task<int> UpdateAppBundleAsync(AppBundle app, string label, string packagePath)
        {
            var id = app.Id;
            try
            {
                app.Id = null;
                var item = await this.CreateAppBundleVersionAsync(id, app);

                await UploadAppBundleBits(item.UploadParameters, packagePath);

                var resp = await this.AppBundlesApi.ModifyAppBundleAliasAsync(id, label, new Alias() { Version = item.Version }, throwOnError: false);
                if (resp.HttpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await this.AppBundlesApi.CreateAppBundleAliasAsync(id, new Alias() { Id = label, Version = item.Version });
                }
                else
                {
                    await resp.HttpResponse.EnsureSuccessStatusCodeAsync();
                }

                return item.Version;
            }
            finally
            {
                app.Id = id;
            }
        }

        public async Task CreateActivityAsync(Activity activity, string label)
        {
            // Create the activity
            var response = await this.CreateActivityAsync(activity);
            // and assign an alias
            await this.CreateActivityAliasAsync(activity.Id, new Alias() { Id = label , Version = response.Version });
        }

        public async Task<int> UpdateActivityAsync(Activity activity, string label)
        {
            var id = activity.Id;
            try
            {
                activity.Id = null;

                var item = await this.CreateActivityVersionAsync(id, activity);

                var resp = await this.ActivitiesApi.ModifyActivityAliasAsync(id, label, new Alias() { Version = item.Version }, throwOnError: false);
                if (resp.HttpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await this.ActivitiesApi.CreateActivityAliasAsync(id, new Alias() { Id = label, Version = item.Version });
                }
                else
                {
                    await resp.HttpResponse.EnsureSuccessStatusCodeAsync();
                }

                return item.Version;
            }
            finally
            {
                activity.Id = id;
            }
        }

        public async Task<List<T>> GetAllItems<T>(Func<string, Task<Page<T>>> pageGetter)
        {
            var ret = new List<T>();
            string paginationToken = null;
            do
            {
                var resp = await pageGetter(paginationToken);
                paginationToken = resp.PaginationToken;
                foreach (var d in resp.Data)
                {
                    ret.AddRange(resp.Data);
                }
            }
            while (paginationToken != null);
            return ret;
        }
    }
}
