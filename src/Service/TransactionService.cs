namespace Tutkoo.mintyfusion.Berbix.Client.Service
{
    #region namespace
    using Interface;
    using Microsoft.Extensions.Configuration;
    using Model.Transaction;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    #endregion namespace

    #region Class
    public class TransactionService : ITransaction
    {
        #region Fields
        private readonly string apiSecret = string.Empty;

        private readonly HttpClient httpClient = null;
        #endregion Fields

        #region Constructor
        public TransactionService(IConfiguration configuration, 
            HttpClient httpClient)
        {
            apiSecret = configuration["Berbix:API_SECRET_KEY"];

            this.httpClient = httpClient;
        }
        #endregion Constructor

        #region Public Methods
        public async Task<TransactionTokenModel> CreateAsync(CreateTransactionModel createTransaction)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Add(
                    "Authorization", string.Format("Basic {0}", Helper.GetBasicAuthentication(apiSecret)));

                string jsonString = JsonSerializer.Serialize(createTransaction, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                });

                HttpResponseMessage response = await httpClient.PostAsync(Constants.TRANSACTION_ENDPOINT,
                    new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

                string responseString = string.Empty;

                if (response.Content != null)
                    responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<TransactionTokenModel>(responseString);

                throw new InvalidOperationException(responseString);
            }
            catch (Exception xe)
            {
                throw new InvalidOperationException(xe.Message);
            }
        }

        public async Task<TransactionVerificationModel> GetVerificationAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException("accessToken");

            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("bearer {0}", accessToken));

                HttpResponseMessage response = await httpClient.GetAsync(Constants.TRANSACTION_ENDPOINT);

                string responseString = string.Empty;

                if (response.Content != null)
                    responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonSerializer.Deserialize<TransactionVerificationModel>(responseString);

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