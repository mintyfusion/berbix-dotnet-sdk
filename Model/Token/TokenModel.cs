namespace Tutkoo.mintyfusion.Berbix.Client.Model.Token
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TokenModel
    {
        #region Properties
        /// <summary>String representing the entity's type.</summary>
        [JsonPropertyName("entity")]
        public string Entity { get; set; }

        /// <summary>Transaction ID that is represented by the access token.</summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>Access token to be used in subsequent API requests for user metadata.</summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>Refresh token to be used to regenerate expired tokens. Omitted if grant_type is refresh_token.</summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>Number of seconds before the access token expires.</summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary></summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>Token to provide to the Berbix frontend SDK for starting the flow. Omitted if grant_type is authorization_code.</summary>
        [JsonPropertyName("client_token")]
        public string ClientToken { get; set; }
        #endregion Properties
    }
    #endregion Class
}