namespace Tutkoo.mintyfusion.Berbix.Client
{
    #region namespace
    using System;
    using System.Text;
    #endregion namespace

    #region Class
    public static class Helper
    {
        #region Public Methods
        public static string GetBasicAuthentication(string username,
            string password = "")
        {
            string secret = string.Format("{0}:{1}", username, password);

            byte[] encoded = new byte[secret.Length];

            encoded = Encoding.UTF8.GetBytes(secret);
            
            return Convert.ToBase64String(encoded);
        }
        #endregion Public Methods
    }
    #endregion Class
}