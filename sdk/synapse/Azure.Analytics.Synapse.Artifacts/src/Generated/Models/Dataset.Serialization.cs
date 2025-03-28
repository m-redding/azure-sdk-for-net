// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    [JsonConverter(typeof(DatasetConverter))]
    public partial class Dataset : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Structure))
            {
                writer.WritePropertyName("structure"u8);
                writer.WriteObjectValue<object>(Structure);
            }
            if (Optional.IsDefined(Schema))
            {
                writer.WritePropertyName("schema"u8);
                writer.WriteObjectValue<object>(Schema);
            }
            writer.WritePropertyName("linkedServiceName"u8);
            writer.WriteObjectValue(LinkedServiceName);
            if (Optional.IsCollectionDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
                writer.WriteStartObject();
                foreach (var item in Parameters)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(Annotations))
            {
                writer.WritePropertyName("annotations"u8);
                writer.WriteStartArray();
                foreach (var item in Annotations)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue<object>(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Folder))
            {
                writer.WritePropertyName("folder"u8);
                writer.WriteObjectValue(Folder);
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue<object>(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static Dataset DeserializeDataset(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AmazonMWSObject": return AmazonMWSObjectDataset.DeserializeAmazonMWSObjectDataset(element);
                    case "AmazonRdsForOracleTable": return AmazonRdsForOracleTableDataset.DeserializeAmazonRdsForOracleTableDataset(element);
                    case "AmazonRdsForSqlServerTable": return AmazonRdsForSqlServerTableDataset.DeserializeAmazonRdsForSqlServerTableDataset(element);
                    case "AmazonRedshiftTable": return AmazonRedshiftTableDataset.DeserializeAmazonRedshiftTableDataset(element);
                    case "AmazonS3Object": return AmazonS3Dataset.DeserializeAmazonS3Dataset(element);
                    case "Avro": return AvroDataset.DeserializeAvroDataset(element);
                    case "AzureBlob": return AzureBlobDataset.DeserializeAzureBlobDataset(element);
                    case "AzureBlobFSFile": return AzureBlobFSDataset.DeserializeAzureBlobFSDataset(element);
                    case "AzureDatabricksDeltaLakeDataset": return AzureDatabricksDeltaLakeDataset.DeserializeAzureDatabricksDeltaLakeDataset(element);
                    case "AzureDataExplorerTable": return AzureDataExplorerTableDataset.DeserializeAzureDataExplorerTableDataset(element);
                    case "AzureDataLakeStoreFile": return AzureDataLakeStoreDataset.DeserializeAzureDataLakeStoreDataset(element);
                    case "AzureMariaDBTable": return AzureMariaDBTableDataset.DeserializeAzureMariaDBTableDataset(element);
                    case "AzureMySqlTable": return AzureMySqlTableDataset.DeserializeAzureMySqlTableDataset(element);
                    case "AzurePostgreSqlTable": return AzurePostgreSqlTableDataset.DeserializeAzurePostgreSqlTableDataset(element);
                    case "AzureSearchIndex": return AzureSearchIndexDataset.DeserializeAzureSearchIndexDataset(element);
                    case "AzureSqlDWTable": return AzureSqlDWTableDataset.DeserializeAzureSqlDWTableDataset(element);
                    case "AzureSqlMITable": return AzureSqlMITableDataset.DeserializeAzureSqlMITableDataset(element);
                    case "AzureSqlTable": return AzureSqlTableDataset.DeserializeAzureSqlTableDataset(element);
                    case "AzureTable": return AzureTableDataset.DeserializeAzureTableDataset(element);
                    case "Binary": return BinaryDataset.DeserializeBinaryDataset(element);
                    case "CassandraTable": return CassandraTableDataset.DeserializeCassandraTableDataset(element);
                    case "CommonDataServiceForAppsEntity": return CommonDataServiceForAppsEntityDataset.DeserializeCommonDataServiceForAppsEntityDataset(element);
                    case "ConcurObject": return ConcurObjectDataset.DeserializeConcurObjectDataset(element);
                    case "CosmosDbMongoDbApiCollection": return CosmosDbMongoDbApiCollectionDataset.DeserializeCosmosDbMongoDbApiCollectionDataset(element);
                    case "CosmosDbSqlApiCollection": return CosmosDbSqlApiCollectionDataset.DeserializeCosmosDbSqlApiCollectionDataset(element);
                    case "CouchbaseTable": return CouchbaseTableDataset.DeserializeCouchbaseTableDataset(element);
                    case "CustomDataset": return CustomDataset.DeserializeCustomDataset(element);
                    case "Db2Table": return Db2TableDataset.DeserializeDb2TableDataset(element);
                    case "DelimitedText": return DelimitedTextDataset.DeserializeDelimitedTextDataset(element);
                    case "DocumentDbCollection": return DocumentDbCollectionDataset.DeserializeDocumentDbCollectionDataset(element);
                    case "DrillTable": return DrillTableDataset.DeserializeDrillTableDataset(element);
                    case "DynamicsAXResource": return DynamicsAXResourceDataset.DeserializeDynamicsAXResourceDataset(element);
                    case "DynamicsCrmEntity": return DynamicsCrmEntityDataset.DeserializeDynamicsCrmEntityDataset(element);
                    case "DynamicsEntity": return DynamicsEntityDataset.DeserializeDynamicsEntityDataset(element);
                    case "EloquaObject": return EloquaObjectDataset.DeserializeEloquaObjectDataset(element);
                    case "Excel": return ExcelDataset.DeserializeExcelDataset(element);
                    case "FileShare": return FileShareDataset.DeserializeFileShareDataset(element);
                    case "GoogleAdWordsObject": return GoogleAdWordsObjectDataset.DeserializeGoogleAdWordsObjectDataset(element);
                    case "GoogleBigQueryObject": return GoogleBigQueryObjectDataset.DeserializeGoogleBigQueryObjectDataset(element);
                    case "GoogleBigQueryV2Object": return GoogleBigQueryV2ObjectDataset.DeserializeGoogleBigQueryV2ObjectDataset(element);
                    case "GreenplumTable": return GreenplumTableDataset.DeserializeGreenplumTableDataset(element);
                    case "HBaseObject": return HBaseObjectDataset.DeserializeHBaseObjectDataset(element);
                    case "HiveObject": return HiveObjectDataset.DeserializeHiveObjectDataset(element);
                    case "HttpFile": return HttpDataset.DeserializeHttpDataset(element);
                    case "HubspotObject": return HubspotObjectDataset.DeserializeHubspotObjectDataset(element);
                    case "Iceberg": return IcebergDataset.DeserializeIcebergDataset(element);
                    case "ImpalaObject": return ImpalaObjectDataset.DeserializeImpalaObjectDataset(element);
                    case "InformixTable": return InformixTableDataset.DeserializeInformixTableDataset(element);
                    case "JiraObject": return JiraObjectDataset.DeserializeJiraObjectDataset(element);
                    case "Json": return JsonDataset.DeserializeJsonDataset(element);
                    case "LakehouseTable": return LakeHouseTableDataset.DeserializeLakeHouseTableDataset(element);
                    case "MagentoObject": return MagentoObjectDataset.DeserializeMagentoObjectDataset(element);
                    case "MariaDBTable": return MariaDBTableDataset.DeserializeMariaDBTableDataset(element);
                    case "MarketoObject": return MarketoObjectDataset.DeserializeMarketoObjectDataset(element);
                    case "MicrosoftAccessTable": return MicrosoftAccessTableDataset.DeserializeMicrosoftAccessTableDataset(element);
                    case "MongoDbAtlasCollection": return MongoDbAtlasCollectionDataset.DeserializeMongoDbAtlasCollectionDataset(element);
                    case "MongoDbCollection": return MongoDbCollectionDataset.DeserializeMongoDbCollectionDataset(element);
                    case "MongoDbV2Collection": return MongoDbV2CollectionDataset.DeserializeMongoDbV2CollectionDataset(element);
                    case "MySqlTable": return MySqlTableDataset.DeserializeMySqlTableDataset(element);
                    case "NetezzaTable": return NetezzaTableDataset.DeserializeNetezzaTableDataset(element);
                    case "ODataResource": return ODataResourceDataset.DeserializeODataResourceDataset(element);
                    case "OdbcTable": return OdbcTableDataset.DeserializeOdbcTableDataset(element);
                    case "Office365Table": return Office365Dataset.DeserializeOffice365Dataset(element);
                    case "OracleServiceCloudObject": return OracleServiceCloudObjectDataset.DeserializeOracleServiceCloudObjectDataset(element);
                    case "OracleTable": return OracleTableDataset.DeserializeOracleTableDataset(element);
                    case "Orc": return OrcDataset.DeserializeOrcDataset(element);
                    case "Parquet": return ParquetDataset.DeserializeParquetDataset(element);
                    case "PaypalObject": return PaypalObjectDataset.DeserializePaypalObjectDataset(element);
                    case "PhoenixObject": return PhoenixObjectDataset.DeserializePhoenixObjectDataset(element);
                    case "PostgreSqlTable": return PostgreSqlTableDataset.DeserializePostgreSqlTableDataset(element);
                    case "PostgreSqlV2Table": return PostgreSqlV2TableDataset.DeserializePostgreSqlV2TableDataset(element);
                    case "PrestoObject": return PrestoObjectDataset.DeserializePrestoObjectDataset(element);
                    case "QuickBooksObject": return QuickBooksObjectDataset.DeserializeQuickBooksObjectDataset(element);
                    case "RelationalTable": return RelationalTableDataset.DeserializeRelationalTableDataset(element);
                    case "ResponsysObject": return ResponsysObjectDataset.DeserializeResponsysObjectDataset(element);
                    case "RestResource": return RestResourceDataset.DeserializeRestResourceDataset(element);
                    case "SalesforceMarketingCloudObject": return SalesforceMarketingCloudObjectDataset.DeserializeSalesforceMarketingCloudObjectDataset(element);
                    case "SalesforceObject": return SalesforceObjectDataset.DeserializeSalesforceObjectDataset(element);
                    case "SalesforceServiceCloudObject": return SalesforceServiceCloudObjectDataset.DeserializeSalesforceServiceCloudObjectDataset(element);
                    case "SalesforceServiceCloudV2Object": return SalesforceServiceCloudV2ObjectDataset.DeserializeSalesforceServiceCloudV2ObjectDataset(element);
                    case "SalesforceV2Object": return SalesforceV2ObjectDataset.DeserializeSalesforceV2ObjectDataset(element);
                    case "SapBwCube": return SapBwCubeDataset.DeserializeSapBwCubeDataset(element);
                    case "SapCloudForCustomerResource": return SapCloudForCustomerResourceDataset.DeserializeSapCloudForCustomerResourceDataset(element);
                    case "SapEccResource": return SapEccResourceDataset.DeserializeSapEccResourceDataset(element);
                    case "SapHanaTable": return SapHanaTableDataset.DeserializeSapHanaTableDataset(element);
                    case "SapOdpResource": return SapOdpResourceDataset.DeserializeSapOdpResourceDataset(element);
                    case "SapOpenHubTable": return SapOpenHubTableDataset.DeserializeSapOpenHubTableDataset(element);
                    case "SapTableResource": return SapTableResourceDataset.DeserializeSapTableResourceDataset(element);
                    case "ServiceNowObject": return ServiceNowObjectDataset.DeserializeServiceNowObjectDataset(element);
                    case "ServiceNowV2Object": return ServiceNowV2ObjectDataset.DeserializeServiceNowV2ObjectDataset(element);
                    case "SharePointOnlineListResource": return SharePointOnlineListResourceDataset.DeserializeSharePointOnlineListResourceDataset(element);
                    case "ShopifyObject": return ShopifyObjectDataset.DeserializeShopifyObjectDataset(element);
                    case "SnowflakeTable": return SnowflakeDataset.DeserializeSnowflakeDataset(element);
                    case "SnowflakeV2Table": return SnowflakeV2Dataset.DeserializeSnowflakeV2Dataset(element);
                    case "SparkObject": return SparkObjectDataset.DeserializeSparkObjectDataset(element);
                    case "SqlServerTable": return SqlServerTableDataset.DeserializeSqlServerTableDataset(element);
                    case "SquareObject": return SquareObjectDataset.DeserializeSquareObjectDataset(element);
                    case "SybaseTable": return SybaseTableDataset.DeserializeSybaseTableDataset(element);
                    case "TeradataTable": return TeradataTableDataset.DeserializeTeradataTableDataset(element);
                    case "VerticaTable": return VerticaTableDataset.DeserializeVerticaTableDataset(element);
                    case "WarehouseTable": return WarehouseTableDataset.DeserializeWarehouseTableDataset(element);
                    case "WebTable": return WebTableDataset.DeserializeWebTableDataset(element);
                    case "XeroObject": return XeroObjectDataset.DeserializeXeroObjectDataset(element);
                    case "Xml": return XmlDataset.DeserializeXmlDataset(element);
                    case "ZohoObject": return ZohoObjectDataset.DeserializeZohoObjectDataset(element);
                }
            }
            return UnknownDataset.DeserializeUnknownDataset(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Dataset FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeDataset(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal partial class DatasetConverter : JsonConverter<Dataset>
        {
            public override void Write(Utf8JsonWriter writer, Dataset model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }

            public override Dataset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDataset(document.RootElement);
            }
        }
    }
}
