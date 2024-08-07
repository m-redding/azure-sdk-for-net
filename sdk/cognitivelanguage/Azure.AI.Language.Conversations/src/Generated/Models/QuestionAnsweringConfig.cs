// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> This is a set of request parameters for Question Answering knowledge bases. </summary>
    public partial class QuestionAnsweringConfig : AnalysisConfig
    {
        /// <summary> Initializes a new instance of <see cref="QuestionAnsweringConfig"/>. </summary>
        public QuestionAnsweringConfig()
        {
            TargetProjectKind = TargetProjectKind.QuestionAnswering;
        }

        /// <summary> Initializes a new instance of <see cref="QuestionAnsweringConfig"/>. </summary>
        /// <param name="targetProjectKind"> The type of a target service. </param>
        /// <param name="apiVersion"> The API version to use when call a specific target service. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="callingOptions"> The options sent to a Question Answering KB. </param>
        internal QuestionAnsweringConfig(TargetProjectKind targetProjectKind, string apiVersion, IDictionary<string, BinaryData> serializedAdditionalRawData, QuestionAnswersConfig callingOptions) : base(targetProjectKind, apiVersion, serializedAdditionalRawData)
        {
            CallingOptions = callingOptions;
        }

        /// <summary> The options sent to a Question Answering KB. </summary>
        public QuestionAnswersConfig CallingOptions { get; set; }
    }
}
