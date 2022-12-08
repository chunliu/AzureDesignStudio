// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// DatabaseProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DatabaseProperties
    {
        /// <summary>
        /// Specifies the mode of database creation.

        [JsonPropertyName("createMode")]
        public string CreateMode { get; set; }

        /// <summary>
        /// The collation of the database.
        /// </summary>
        [JsonPropertyName("collation")]
        public string Collation { get; set; }

        /// <summary>
        /// The max size of the database expressed in bytes.
        /// </summary>
        [JsonPropertyName("maxSizeBytes")]
        public int MaxSizeBytes { get; set; }

        /// <summary>
        /// The name of the sample schema to apply when creating this database.
        /// </summary>
        [JsonPropertyName("sampleName")]
        public string SampleName { get; set; }

        /// <summary>
        /// The resource identifier of the elastic pool containing this database.
        /// </summary>
        [JsonPropertyName("elasticPoolId")]
        public string ElasticPoolId { get; set; }

        /// <summary>
        /// The resource identifier of the source database associated with create operation of this database.
        /// </summary>
        [JsonPropertyName("sourceDatabaseId")]
        public string SourceDatabaseId { get; set; }

        /// <summary>
        /// The status of the database.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The ID of the database.
        /// </summary>
        [JsonPropertyName("databaseId")]
        public string DatabaseId { get; set; }

        /// <summary>
        /// The creation date of the database (ISO8601 format).
        /// </summary>
        [JsonPropertyName("creationDate")]
        public string CreationDate { get; set; }

        /// <summary>
        /// The current service level objective name of the database.
        /// </summary>
        [JsonPropertyName("currentServiceObjectiveName")]
        public string CurrentServiceObjectiveName { get; set; }

        /// <summary>
        /// The requested service level objective name of the database.
        /// </summary>
        [JsonPropertyName("requestedServiceObjectiveName")]
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// The default secondary region for this database.
        /// </summary>
        [JsonPropertyName("defaultSecondaryLocation")]
        public string DefaultSecondaryLocation { get; set; }

        /// <summary>
        /// Failover Group resource identifier that this database belongs to.
        /// </summary>
        [JsonPropertyName("failoverGroupId")]
        public string FailoverGroupId { get; set; }

        /// <summary>
        /// Specifies the point in time (ISO8601 format) of the source database that will be restored to create the new database.
        /// </summary>
        [JsonPropertyName("restorePointInTime")]
        public string RestorePointInTime { get; set; }

        /// <summary>
        /// Specifies the time that the database was deleted.
        /// </summary>
        [JsonPropertyName("sourceDatabaseDeletionDate")]
        public string SourceDatabaseDeletionDate { get; set; }

        /// <summary>
        /// The resource identifier of the recovery point associated with create operation of this database.
        /// </summary>
        [JsonPropertyName("recoveryServicesRecoveryPointId")]
        public string RecoveryServicesRecoveryPointId { get; set; }

        /// <summary>
        /// The resource identifier of the long term retention backup associated with create operation of this database.
        /// </summary>
        [JsonPropertyName("longTermRetentionBackupResourceId")]
        public string LongTermRetentionBackupResourceId { get; set; }

        /// <summary>
        /// The resource identifier of the recoverable database associated with create operation of this database.
        /// </summary>
        [JsonPropertyName("recoverableDatabaseId")]
        public string RecoverableDatabaseId { get; set; }

        /// <summary>
        /// The resource identifier of the restorable dropped database associated with create operation of this database.
        /// </summary>
        [JsonPropertyName("restorableDroppedDatabaseId")]
        public string RestorableDroppedDatabaseId { get; set; }

        /// <summary>
        /// Collation of the metadata catalog.
        /// </summary>
        [JsonPropertyName("catalogCollation")]
        public string CatalogCollation { get; set; }

        /// <summary>
        /// Whether or not this database is zone redundant, which means the replicas of this database will be spread across multiple availability zones.
        /// </summary>
        [JsonPropertyName("zoneRedundant")]
        public bool ZoneRedundant { get; set; }

        /// <summary>
        /// The license type to apply for this database. `LicenseIncluded` if you need a license, or `BasePrice` if you have a license and are eligible for the Azure Hybrid Benefit.
        /// </summary>
        [JsonPropertyName("licenseType")]
        public string LicenseType { get; set; }

        /// <summary>
        /// The max log size for this database.
        /// </summary>
        [JsonPropertyName("maxLogSizeBytes")]
        public int MaxLogSizeBytes { get; set; }

        /// <summary>
        /// This records the earliest start date and time that restore is available for this database (ISO8601 format).
        /// </summary>
        [JsonPropertyName("earliestRestoreDate")]
        public string EarliestRestoreDate { get; set; }

        /// <summary>
        /// The state of read-only routing. If enabled, connections that have application intent set to readonly in their connection string may be routed to a readonly secondary replica in the same region. Not applicable to a Hyperscale database within an elastic pool.
        /// </summary>
        [JsonPropertyName("readScale")]
        public string ReadScale { get; set; }

        /// <summary>
        /// The number of secondary replicas associated with the database that are used to provide high availability. Not applicable to a Hyperscale database within an elastic pool.
        /// </summary>
        [JsonPropertyName("highAvailabilityReplicaCount")]
        public int HighAvailabilityReplicaCount { get; set; }

        /// <summary>
        /// The secondary type of the database if it is a secondary.  Valid values are Geo, Named and Standby.
        /// </summary>
        [JsonPropertyName("secondaryType")]
        public string SecondaryType { get; set; }

        /// <summary>
        /// The name and tier of the SKU.
        /// </summary>
        [JsonPropertyName("currentSku")]
        public Sku CurrentSku { get; set; }

        /// <summary>
        /// Time in minutes after which database is automatically paused. A value of -1 means that automatic pause is disabled
        /// </summary>
        [JsonPropertyName("autoPauseDelay")]
        public int AutoPauseDelay { get; set; }

        /// <summary>
        /// The storage account type used to store backups for this database.
        /// </summary>
        [JsonPropertyName("currentBackupStorageRedundancy")]
        public string CurrentBackupStorageRedundancy { get; set; }

        /// <summary>
        /// The storage account type to be used to store backups for this database.
        /// </summary>
        [JsonPropertyName("requestedBackupStorageRedundancy")]
        public string RequestedBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Minimal capacity that database will always have allocated, if not paused
        /// </summary>
        [JsonPropertyName("minCapacity")]
        public int MinCapacity { get; set; }

        /// <summary>
        /// The date when database was paused by user configuration or action(ISO8601 format). Null if the database is ready.
        /// </summary>
        [JsonPropertyName("pausedDate")]
        public string PausedDate { get; set; }

        /// <summary>
        /// The date when database was resumed by user action or database login (ISO8601 format). Null if the database is paused.
        /// </summary>
        [JsonPropertyName("resumedDate")]
        public string ResumedDate { get; set; }

        /// <summary>
        /// Maintenance configuration id assigned to the database. This configuration defines the period when the maintenance updates will occur.
        /// </summary>
        [JsonPropertyName("maintenanceConfigurationId")]
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Whether or not this database is a ledger database, which means all tables in the database are ledger tables. Note: the value of this property cannot be changed after the database has been created.
        /// </summary>
        [JsonPropertyName("isLedgerOn")]
        public bool IsLedgerOn { get; set; }

        /// <summary>
        /// Infra encryption is enabled for this database.
        /// </summary>
        [JsonPropertyName("isInfraEncryptionEnabled")]
        public bool IsInfraEncryptionEnabled { get; set; }

        /// <summary>
        /// The Client id used for cross tenant per database CMK scenario
        /// </summary>
        [JsonPropertyName("federatedClientId")]
        public string FederatedClientId { get; set; }

        /// <summary>
        /// Type of enclave requested on the database i.e. Default or VBS enclaves.
        /// </summary>
        [JsonPropertyName("preferredEnclaveType")]
        public string PreferredEnclaveType { get; set; }

        /// <summary>
        /// The resource identifier of the source associated with the create operation of this database.

        [JsonPropertyName("sourceResourceId")]
        public string SourceResourceId { get; set; }
    }
}