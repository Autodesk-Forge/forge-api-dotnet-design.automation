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
    public interface IWorkItemsApi
    {
        /// <summary>
        /// Creates a new WorkItem and queues it for processing.
        /// </summary>
        /// <remarks>
        /// Creates a new WorkItem and queues it for processing.  The new WorkItem is always placed on the  queue; no further action is necessary.                Limits (Engine-specific):                1. Number of downloads (LimitDownloads)  2. Number of uploads (LimitUploads)  3. Total download size (LimitDownloadSize)  4. Total upload size (LimitUploadSize)  5. Processing time (LimitProcessingTime)  6. Total size of uncompressed bits for all referenced appbundles (LimitTotalUncompressedAppsSizePerActivity).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="workitem"></param>
        /// <returns>Task of WorkItemStatus</returns>
        System.Threading.Tasks.Task<WorkItemStatus> CreateWorkItemsAsync (WorkItem workitem);
        /// <summary>
        /// Cancels a specific WorkItem.
        /// </summary>
        /// <remarks>
        /// Cancels a specific WorkItem.  If the WorkItem is on the queue, it is removed from the queue and not processed.  If the WorkItem is already being processed, then it may or may not be interrupted and cancelled.  If the WorkItem has already finished processing, then it has no effect on the processing or results.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteWorkitemsAsync (string id);
        /// <summary>
        /// Gets the status of a specific WorkItem.
        /// </summary>
        /// <remarks>
        /// Gets the status of a specific WorkItem.  Typically used to &#39;poll&#39; for              the completion of a WorkItem, but see the use of the &#39;onComplete&#39; argument for              an alternative that does not require &#39;polling&#39;.  WorkItem status is retained              for a limited period of time after the WorkItem completes.              Limits:              1. Retention period (LimitWorkItemRetentionPeriod).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of WorkItemStatus</returns>
        System.Threading.Tasks.Task<WorkItemStatus> GetWorkitemsStatusAsync (string id);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class WorkItemsApi : IWorkItemsApi
    {
        public readonly WorkItemsApiHttp LowLevelApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItemsApi"/> class
        /// using ForgeService object
        /// </summary>
        /// <param name="service">An instance of ForgeService</param>
        /// <returns></returns>
        public WorkItemsApi(ForgeService service = null, IOptions<Configuration> configuration = null)
        {
            this.LowLevelApi = new WorkItemsApiHttp(service, configuration);
        }

        /// <summary>
        /// Creates a new WorkItem and queues it for processing. Creates a new WorkItem and queues it for processing.  The new WorkItem is always placed on the  queue; no further action is necessary.                Limits (Engine-specific):                1. Number of downloads (LimitDownloads)  2. Number of uploads (LimitUploads)  3. Total download size (LimitDownloadSize)  4. Total upload size (LimitUploadSize)  5. Processing time (LimitProcessingTime)  6. Total size of uncompressed bits for all referenced appbundles (LimitTotalUncompressedAppsSizePerActivity).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="workitem"></param>
        /// <returns>Task of WorkItemStatus</returns>
        public async System.Threading.Tasks.Task<WorkItemStatus> CreateWorkItemsAsync (WorkItem workitem)
        {
             var localVarResponse = await this.LowLevelApi.CreateWorkItemsAsync(workitem);
             return localVarResponse.Content;

        }
        /// <summary>
        /// Cancels a specific WorkItem. Cancels a specific WorkItem.  If the WorkItem is on the queue, it is removed from the queue and not processed.  If the WorkItem is already being processed, then it may or may not be interrupted and cancelled.  If the WorkItem has already finished processing, then it has no effect on the processing or results.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteWorkitemsAsync (string id)
        {
             await this.LowLevelApi.DeleteWorkitemsAsync(id);

        }
        /// <summary>
        /// Gets the status of a specific WorkItem. Gets the status of a specific WorkItem.  Typically used to &#39;poll&#39; for              the completion of a WorkItem, but see the use of the &#39;onComplete&#39; argument for              an alternative that does not require &#39;polling&#39;.  WorkItem status is retained              for a limited period of time after the WorkItem completes.              Limits:              1. Retention period (LimitWorkItemRetentionPeriod).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>Task of WorkItemStatus</returns>
        public async System.Threading.Tasks.Task<WorkItemStatus> GetWorkitemsStatusAsync (string id)
        {
             var localVarResponse = await this.LowLevelApi.GetWorkitemsStatusAsync(id);
             return localVarResponse.Content;

        }
    }
}
