namespace Tutkoo.mintyfusion.Berbix.Client.Model.Field
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class SourceModel
    {
        #region Properties
        /// <summary></summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary></summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary></summary>
        [JsonPropertyName("confidence")]
        public string Confidence { get; set; }
        #endregion Properties
    }
    #endregion Class
}