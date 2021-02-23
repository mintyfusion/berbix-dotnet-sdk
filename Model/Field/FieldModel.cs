namespace Tutkoo.mintyfusion.Berbix.Client.Model.Field
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class FieldModel
    {
        #region Properties
        /// <summary></summary>
        [JsonPropertyName("given_name")]
        public GivenNameFieldModel GivenName { get; set; }
        #endregion Properties
    }
    #endregion Class
}