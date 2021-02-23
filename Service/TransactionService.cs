namespace Tutkoo.mintyfusion.Berbix.Client.Service
{
    #region namespace
    using Interface;
    using System.Net.Http;
    #endregion namespace

    #region Class
    public class TransactionService : ITransaction
    {
        #region Fields
        private readonly HttpClient httpClient = null;
        #endregion Fields

        #region Constructor
        public TransactionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        #endregion Constructor
    }
    #endregion Class
}