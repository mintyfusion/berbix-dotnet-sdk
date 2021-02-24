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
    using Tutkoo.mintyfusion.Berbix.Client.Model.Transaction;
    using Tutkoo.mintyfusion.Berbix.Client.Service;
    #endregion namespace

    #region Class
    public class TransactionTests
    {
        #region Fields
        private IConfiguration configuration = null;

        private ITransaction transactionService = null;
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

            transactionService = new TransactionService(configuration["API_SECRET_KEY"],
                httpClient);
        }

        [Test]
        public async Task GetTransaction()
        {
            TransactionVerificationModel verification =  await transactionService.GetVerificationAsync(configuration["ACCESS_TOKEN"]);

            Console.WriteLine(JsonSerializer.Serialize(verification));
        }

        [Test]
        public async Task CreateTransaction()
        {
            CreateTransactionModel createTransaction = new CreateTransactionModel
            {
                CustomerId = "TEST_ID",
                TemplateKey = configuration["TEMPLATE_KEY"],
                HostedOptions = new HostedOptionsModel
                {
                    CompletionEmail = configuration["EMAIL"]
                },
                Phone = configuration["PHONE"]
            };

            TransactionTokenModel token = await transactionService.CreateAsync(createTransaction);

            Console.WriteLine(JsonSerializer.Serialize(token));
        }
        #endregion Public Methods
    }
    #endregion Class
}