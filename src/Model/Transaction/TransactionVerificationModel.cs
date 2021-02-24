namespace Tutkoo.mintyfusion.Berbix.Client.Model.Transaction
{
    #region namespace
    using Field;
    using System;
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TransactionVerificationModel
    {
        #region Properties
        /// <summary></summary>
        [JsonPropertyName("entity")]
        public string Entity { get; set; }

        /// <summary></summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary></summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary></summary>
        [JsonPropertyName("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        /// <summary></summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary></summary>
        [JsonPropertyName("fields")]
        public FieldModel Fields { get; set; }
        #endregion Properties
    }
    #endregion Class
}