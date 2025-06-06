// Copyright 2025 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START pubsub_create_topic_with_aws_msk_ingestion]

using Google.Cloud.PubSub.V1;
using System;

public class CreateTopicWithAwsMskIngestionSample
{
    public Topic CreateTopicWithAwsMskIngestion(string projectId, string topicId, string clusterArn, string mskTopic, string awsRoleArn, string gcpServiceAccount)
    {
        // Define settings for Amazon MSK ingestion
        IngestionDataSourceSettings ingestionDataSourceSettings = new IngestionDataSourceSettings
        {
            AwsMsk = new IngestionDataSourceSettings.Types.AwsMsk
            {
                ClusterArn = clusterArn,
                Topic = mskTopic,
                AwsRoleArn = awsRoleArn,
                GcpServiceAccount = gcpServiceAccount
            }
        };
        
        PublisherServiceApiClient publisher = PublisherServiceApiClient.Create();
        Topic topic = new Topic()
        {
            Name = TopicName.FormatProjectTopic(projectId, topicId),
            IngestionDataSourceSettings = ingestionDataSourceSettings
        };
        Topic createdTopic = publisher.CreateTopic(topic);
        Console.WriteLine($"Topic {topic.Name} created.");

        return createdTopic;
    }
}

// [END pubsub_create_topic_with_aws_msk_ingestion]
