namespace Tutkoo.mintyfusion.Berbix.Client.Model.Transaction
{
    #region namespace
    using System.Text.Json.Serialization;
    using Token;
    #endregion namespace

    #region Class
    public class TransactionTokenModel : TokenModel
    {
        #region Properties
        /// <summary>Hosted URL generated if the hosted options have been specified.</summary>
        [JsonPropertyName("hosted_url")]
        public string HostedUrl { get; set; }
        #endregion Properties
    }
    #endregion Class
}