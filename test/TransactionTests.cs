namespace Tutkoo.mintyfusion.Berbix.Client.Tests
{
    #region namespace
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using NUnit.Framework;
    using System;
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

        public IServiceProvider ServiceProvider { get; set; }
        #endregion Fields

        #region Public Methods
        [SetUp]
        public void Setup()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();

            configBuilder.AddUserSecrets<TransactionTests>();

            configuration = configBuilder.Build();

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddSingleton(configuration);

                   services.AddHttpClient(Constants.HTTP_NAMED_CLIENT,
                       x => x.BaseAddress = new Uri(Constants.API_URL));

                   services.AddScoped<ITransaction, TransactionService>();
               }).Build();

            ServiceProvider = builder.Services;
        }

        [Test]
        public async Task GetTransaction()
        {
            ITransaction transactionService = (ITransaction)ServiceProvider.GetService(typeof(ITransaction));

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

            ITransaction transactionService = (ITransaction)ServiceProvider.GetService(typeof(ITransaction));

            TransactionTokenModel token = await transactionService.CreateAsync(createTransaction);

            Console.WriteLine(JsonSerializer.Serialize(token));
        }
        #endregion Public Methods
    }
    #endregion Class
}