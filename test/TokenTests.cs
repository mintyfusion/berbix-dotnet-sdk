namespace Tutkoo.mintyfusion.Berbix.Client.Tests
{
    #region namespace
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Tutkoo.mintyfusion.Berbix.Client.Interface;
    using Tutkoo.mintyfusion.Berbix.Client.Model.Token;
    using Tutkoo.mintyfusion.Berbix.Client.Service;
    #endregion namespace

    #region Class
    public class TokenTests
    {
        #region Fields
        private IConfiguration configuration = null;

        private IToken tokenService = null;
        #endregion Fields

        #region Public Methods
        [SetUp]
        public void Setup()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();

            configBuilder.AddUserSecrets<TransactionTests>();

            configuration = configBuilder.Build();

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.API_URL)
            };

            tokenService = new TokenService(configuration,
                httpClient);
        }

        [Test]
        public async Task GetToken()
        {
            TokenModel token = await tokenService.CreateAsync(configuration["REFRESH_TOKEN"]);

            Console.WriteLine(JsonSerializer.Serialize(token));
        }
        #endregion Public Methods
    }
    #endregion Class
}