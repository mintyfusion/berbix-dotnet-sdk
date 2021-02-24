namespace Tutkoo.mintyfusion.Berbix.Client.Model.Transaction
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class HostedOptionsModel
    {
        #region Properties
        /// <summary>Email address to alert when transaction has been completed.</summary>
        [JsonPropertyName("completion_email")]
        public string CompletionEmail { get; set; }

        /// <summary>URL to redirect the user to after they complete the transaction. If not specified, the URL specified in the Berbix dashboard will be used instead.</summary>
        [JsonPropertyName("redirect_url")]
        public string Redirect_Url { get; set; }
        #endregion Properties
    }
    #endregion Class
}