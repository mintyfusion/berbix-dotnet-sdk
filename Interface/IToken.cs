namespace Tutkoo.mintyfusion.Berbix.Client.Interface
{
    #region namespace
    using Model.Token;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IToken
    {
        #region Methods
        Task<TokenModel> CreateToken(string refreshToken);
        #endregion Methods
    }
    #endregion Interface
}