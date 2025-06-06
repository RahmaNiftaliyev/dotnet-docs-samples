/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https:www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// [START workflows_execute_without_arguments]

using Google.Cloud.Workflows.Common.V1;
using Google.Cloud.Workflows.Executions.V1;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ExecuteWorkflowSample
{
    /// <summary>
    /// Execute a workflow and return the execution operation.
    /// </summary>
    /// <param name="projectID">Your Google Cloud Project ID.</param>
    /// <param name="locationID">The region where your workflow is located.</param>
    /// <param name="workflowID">Your Workflow ID.</param>
    /// <returns>
    /// An Execute object representing the completed workflow execution.
    /// </returns>
    public async Task<Execution> ExecuteWorkflow(
        string projectId = "YOUR-PROJECT-ID",
        string locationID = "YOUR-LOCATION-ID",
        string workflowID = "YOUR-WORKFLOW-ID")
    {
        // Initialize the client.
        ExecutionsClient client = await ExecutionsClient.CreateAsync();

        // Build the parent location path.
        WorkflowName parent = new WorkflowName(projectId, locationID, workflowID);

        // Create an execution request.
        CreateExecutionRequest createExecutionRequest = new CreateExecutionRequest
        {
            ParentAsWorkflowName = parent,
        };

        // Execute the operation.
        Execution execution = await client.CreateExecutionAsync(createExecutionRequest);
        Console.WriteLine("- Execution started...");

        TimeSpan backoffDelay = TimeSpan.FromSeconds(1);
        TimeSpan maxBackoffDelay = TimeSpan.FromSeconds(16);

        // Keep polling the state until the execution finishes, using exponential backoff.
        while (execution.State == Execution.Types.State.Active)
        {
            await Task.Delay(backoffDelay);

            // Implement exponential backoff by doubling the delay, but limiting it to a practical duration.
            backoffDelay = (backoffDelay < maxBackoffDelay) ? backoffDelay * 2 : maxBackoffDelay;

            execution = await client.GetExecutionAsync(execution.Name);
        }

        // Print results.
        Console.WriteLine($"Execution finished with state: {execution.State}");
        Console.WriteLine($"Execution results: {execution.Result}");

        // Return the fetched execution.
        return execution;
    }
}
// [END workflows_execute_without_arguments]
