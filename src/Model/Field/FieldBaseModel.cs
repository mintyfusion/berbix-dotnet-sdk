namespace Tutkoo.mintyfusion.Berbix.Client.Model.Field
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class FieldBaseModel
    {
        #region Properties
        /// <summary></summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary></summary>
        [JsonPropertyName("confidence")]
        public string Confidence { get; set; }

        /// <summary></summary>
        [JsonPropertyName("sources")]
        public SourceModel[] Sources { get; set; }
        #endregion Properties
    }
    #endregion Class
}