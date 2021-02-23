namespace Tutkoo.mintyfusion.Berbix.Client.Interface
{
    #region namespace
    using Model.Transaction;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface ITransaction
    {
        #region Methods
        Task<TransactionTokenModel> CreateAsync(CreateTransactionModel createTransaction);

        Task<TransactionVerificationModel> GetVerificationAsync(string accessToken);
        #endregion Methods
    }
    #endregion Interface
}