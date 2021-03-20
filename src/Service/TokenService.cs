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
            IHttpClientFactory httpClientFactory)
        {
            apiSecret = configuration[Constants.API_SECRET_KEY_NAME];

            if (string.IsNullOrEmpty(apiSecret))
                throw new InvalidOperationException(string.Format("Please provide a configuration parameter named {0}", Constants.API_SECRET_KEY_NAME));

            httpClient = httpClientFactory.CreateClient(Constants.HTTP_NAMED_CLIENT);

            if (httpClient == null)
                throw new InvalidOperationException(string.Format("Please create a named HttpClient with name {0}", Constants.HTTP_NAMED_CLIENT));
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