// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Search.Documents.Models
{
    /// <summary> A single vector field result. Both @search.score and vector similarity values are returned. Vector similarity is related to @search.score by an equation. </summary>
    public partial class SingleVectorFieldResult
    {
        /// <summary> Initializes a new instance of <see cref="SingleVectorFieldResult"/>. </summary>
        internal SingleVectorFieldResult()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SingleVectorFieldResult"/>. </summary>
        /// <param name="searchScore"> The @search.score value that is calculated from the vector similarity score. This is the score that's visible in a pure single-field single-vector query. </param>
        /// <param name="vectorSimilarity"> The vector similarity score for this document. Note this is the canonical definition of similarity metric, not the 'distance' version. For example, cosine similarity instead of cosine distance. </param>
        internal SingleVectorFieldResult(double? searchScore, double? vectorSimilarity)
        {
            SearchScore = searchScore;
            VectorSimilarity = vectorSimilarity;
        }

        /// <summary> The @search.score value that is calculated from the vector similarity score. This is the score that's visible in a pure single-field single-vector query. </summary>
        public double? SearchScore { get; }
        /// <summary> The vector similarity score for this document. Note this is the canonical definition of similarity metric, not the 'distance' version. For example, cosine similarity instead of cosine distance. </summary>
        public double? VectorSimilarity { get; }
    }
}
