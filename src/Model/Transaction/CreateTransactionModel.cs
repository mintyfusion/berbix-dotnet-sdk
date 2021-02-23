namespace Tutkoo.mintyfusion.Berbix.Client.Model.Transaction
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CreateTransactionModel
    {
        #region Properties
        /// <summary>Unique identifier for the user. Used for duplicate ID detection.</summary>
        [JsonPropertyName("customer_uid")]
        public string CustomerId { get; set; }

        /// <summary>Optional email adress to be used for pre-filling the handoff-to-phone screen on desktop.</summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>Required if using Hosted Flow.</summary>
        [JsonPropertyName("hosted_options")]
        public HostedOptionsModel HostedOptions { get; set; }

        /// <summary>Optional phone number to be used for pre-filling the handoff-to-phone screen on desktop.</summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>Template to associate with this transaction</summary>
        [JsonPropertyName("template_key")]
        public string TemplateKey { get; set; }
        #endregion Properties
    }
    #endregion Class
}