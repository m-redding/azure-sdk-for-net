﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Vector_Store_Batch_Enterprise_File_Search : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task VectorStoreBatchEnterpriseFileSearch()
    {
        #region Snippet:VectorStoreBatchEnterpriseFileSearch_CreateClient_Async
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = System.Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:BatchFileAttachment
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        VectorStore vectorStore = await client.CreateVectorStoreAsync(
            name: "sample_vector_store"
        );

        VectorStoreFileBatch vctFile = await client.CreateVectorStoreFileBatchAsync(
            vectorStoreId: vectorStore.Id,
            dataSources: [ ds ]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
        #endregion
        #region  Snippet:VectorStoreBatchEnterpriseFileSearch_CreateAgentAndThread_Async
        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        Agent agent = await client.CreateAgentAsync(
            model: modelName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );

        AgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );
        #endregion
        #region Snippet:VectorStoreBatchEnterpriseFileSearch_ThreadRun_Async
        ThreadRun run = await client.CreateRunAsync(
            thread.Id,
            agent.Id
        );

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        // Build the map of file IDs to file names.
        string after = null;
        AgentPageableListOfVectorStoreFile storeFiles;
        Dictionary<string, string> dtFiles = [];
        do
        {
            storeFiles = await client.GetVectorStoreFilesAsync(
                vectorStoreId: vectorStore.Id,
                after: after
            );
            after = storeFiles.LastId;
            foreach (VectorStoreFile fle in storeFiles.Data)
            {
                AgentFile agentFile = await client.GetFileAsync(fle.Id);
                Uri uriFile = new(agentFile.Filename);
                dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
            }
        }
        while (storeFiles.HasMore);
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:VectorStoreBatchEnterpriseFileSearch_Cleanup_Async
        VectorStoreDeletionStatus delStatus = await client.DeleteVectorStoreAsync(vectorStore.Id);
        if (delStatus.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void VectorStoreBatchEnterpriseFileSearchSync()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = System.Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #region Snippet:BatchFileAttachment_Sync
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        VectorStore vectorStore = client.CreateVectorStore(
            name: "sample_vector_store"
        );

        VectorStoreFileBatch vctFile = client.CreateVectorStoreFileBatch(
            vectorStoreId: vectorStore.Id,
            dataSources: [ds]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
        #endregion
        #region  Snippet:VectorStoreBatchEnterpriseFileSearch_CreateAgentAndThread
        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        Agent agent = client.CreateAgent(
            model: modelName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );

        AgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );
        #endregion
        #region Snippet:VectorStoreBatchEnterpriseFileSearch_ThreadRun
        ThreadRun run = client.CreateRun(
            thread.Id,
            agent.Id
        );

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        // Build the map of file IDs to file names.
        string after = null;
        AgentPageableListOfVectorStoreFile storeFiles;
        Dictionary<string, string> dtFiles = [];
        do
        {
            storeFiles = client.GetVectorStoreFiles(
                vectorStoreId: vectorStore.Id,
            after: after
                );
            after = storeFiles.LastId;
            foreach (VectorStoreFile fle in storeFiles.Data)
            {
                AgentFile agentFile = client.GetFile(fle.Id);
                Uri uriFile = new(agentFile.Filename);
                dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
            }
        }
        while (storeFiles.HasMore);
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:VectorStoreBatchEnterpriseFileSearch_Cleanup
        VectorStoreDeletionStatus delStatus = client.DeleteVectorStore(vectorStore.Id);
        if (delStatus.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:VectorStoreBatchEnterpriseFileSearch_Print
    private static void WriteMessages(IEnumerable<ThreadMessage> messages, Dictionary<string, string> fileIds)
    {
        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        string strMessage = textItem.Text;
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextFilePathAnnotation pathAnnotation)
                            {
                                strMessage = replaceReferences(fileIds, pathAnnotation.FileId, pathAnnotation.Text, strMessage);
                            }
                            else if (annotation is MessageTextFileCitationAnnotation citationAnnotation)
                            {
                                strMessage = replaceReferences(fileIds, citationAnnotation.FileId, citationAnnotation.Text, strMessage);
                            }
                        }
                        Console.Write(strMessage);
                    }
                    else
                    {
                        Console.Write(textItem.Text);
                    }
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
    }

    private static string replaceReferences(Dictionary<string, string> fileIds, string fileID, string placeholder, string text)
    {
        if (fileIds.TryGetValue(fileID, out string replacement))
            return text.Replace(placeholder, $" [{replacement}]");
        else
            return text.Replace(placeholder, $" [{fileID}]");
    }
    #endregion
}
