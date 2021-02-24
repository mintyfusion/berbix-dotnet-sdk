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

        /// <summary></summary>
        [JsonPropertyName("middle_name")]
        public MiddleNameModel MiddleNameModel { get; set; }

        /// <summary></summary>
        [JsonPropertyName("family_name")]
        public FamilyNameModel FamilyName { get; set; }

        /// <summary></summary>
        [JsonPropertyName("date_of_birth")]
        public DateOfBirthModel DateOfBirth { get; set; }

        /// <summary></summary>
        [JsonPropertyName("id_expiry_date")]
        public IdExpiryDateModel IdExpiryDate { get; set; }

        /// <summary></summary>
        [JsonPropertyName("id_number")]
        public IdNumberModel IdNumber { get; set; }

        /// <summary></summary>
        [JsonPropertyName("id_type")]
        public IdTypeModel IdType { get; set; }

        /// <summary></summary>
        [JsonPropertyName("id_issuer")]
        public IdIssuerModel IdIssuer { get; set; }

        /// <summary></summary>
        [JsonPropertyName("address_street")]
        public AddressStreetModel AddressStreet { get; set; }

        /// <summary></summary>
        [JsonPropertyName("address_city")]
        public AddressCityModel AddressCity { get; set; }

        /// <summary></summary>
        [JsonPropertyName("address_subdivision")]
        public AddressSubdivisionModel AddressSubdivision { get; set; }

        /// <summary></summary>
        [JsonPropertyName("address_postal_code")]
        public AddressPostalcodeModel AddressPostalcode { get; set; }

        /// <summary></summary>
        [JsonPropertyName("address_country")]
        public AddressCountryModel AddressCountry { get; set; }
        #endregion Properties
    }
    #endregion Class
}