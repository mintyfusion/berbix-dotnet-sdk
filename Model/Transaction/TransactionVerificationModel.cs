namespace Tutkoo.mintyfusion.Berbix.Client.Model.Transaction
{
    #region namespace
    using Field;
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TransactionVerificationModel
    {
        #region Properties
        /// <summary></summary>
        [JsonPropertyName("fields")]
        public FieldModel Fields { get; set; }
        #endregion Properties
    }
    #endregion Class
}