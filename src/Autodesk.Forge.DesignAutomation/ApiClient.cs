using Autodesk.Forge.DesignAutomation.Model;
using Autodesk.Forge.DesignAutomation.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;

namespace Autodesk.Forge.DesignAutomation
{
    public partial class DesignAutomationClient
    {

        private static MultipartFormDataContent ToMultipartFormDataContent( IDictionary<string, string> data)
        {
            var formData = new MultipartFormDataContent();
            foreach (var kv in data)
            {
                if (kv.Value != null)
                {
                    formData.Add(new StringContent(kv.Value), kv.Key);
                }
            }
            return formData;
        }
        public async Task CreateAppBundleAsync(AppBundle app, string label, string packagePath)
        {
            var item = (await appBundlesApi.CreateAppBundleAsync(app)).Content;

            using (var formData = ToMultipartFormDataContent(item.UploadParameters.FormData))
            {
                using (var content = new StreamContent(new FileStream(packagePath, FileMode.Open)))
                {
                    formData.Add(content, "file");
                    var response = await Service.Client.PostAsync(item.UploadParameters.EndpointURL, formData);
                    response.EnsureSuccessStatusCode();
                }
            }

            await appBundlesApi.CreateAppBundleAliasAsync(app.Id, new Alias() { Id = label, Version = item.Version });
        }
    }
}
