/* 
 * Forge Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/design-automation/forge-rsdk-codegen)
 */

using Autodesk.Forge.Core;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Autodesk.Forge.DesignAutomation.Http;
using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.DesignAutomation
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the health status by Engine or for all Engines (Inventor, AutoCAD ...).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="engine"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> HealthStatusAsync (string engine);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HealthApi : IHealthApi
    {
        public readonly HealthApiHttp LowLevelApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class
        /// using ForgeService object
        /// </summary>
        /// <param name="service">An instance of ForgeService</param>
        /// <returns></returns>
        public HealthApi(ForgeService service = null, IOptions<Configuration> configuration = null)
        {
            this.LowLevelApi = new HealthApiHttp(service, configuration);
        }

        /// <summary>
        ///  Gets the health status by Engine or for all Engines (Inventor, AutoCAD ...).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="engine"></param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> HealthStatusAsync (string engine)
        {
             var localVarResponse = await this.LowLevelApi.HealthStatusAsync(engine);
             return localVarResponse.Content;

        }
    }
}
