namespace Tutkoo.mintyfusion.Berbix.Client.Service
{
    #region namespace
    using Interface;
    using Microsoft.Extensions.Configuration;
    using Model.Token;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    #endregion namespace

    #region Class
    public class TokenService : IToken
    {
        #region Fields
        private readonly string apiSecret = string.Empty;

        private readonly HttpClient httpClient = null;
        #endregion Fields

        #region Constructor
        public TokenService(IConfiguration configuration,
            HttpClient httpClient)
        {
            apiSecret = configuration["Berbix:API_SECRET_KEY"];

            this.httpClient = httpClient;
        }
        #endregion Constructor

        #region Public Methods
        public async Task<TokenModel> CreateAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException("refreshToken");

            try
            {
                httpClient.DefaultRequestHeaders.Add(
                    "Authorization", string.Format("Basic {0}", Helper.GetBasicAuthentication(apiSecret)));

                TokenModel request = new TokenModel
                {
                    RefreshToken = refreshToken,
                };

                string jsonString = JsonSerializer.Serialize(request, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                });

                HttpResponseMessage response = await httpClient.PostAsync(Constants.TOKEN_ENDPOINT,
                    new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

                string responseString = string.Empty;

                if (response.Content != null)
                    responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<TokenModel>(responseString);

                throw new InvalidOperationException(responseString);
            }
            catch (Exception xe)
            {
                throw new InvalidOperationException(xe.Message);
            }
        }
        #endregion Public Methods
    }
    #endregion Class
}