using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using ZendeskApi_v2;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskProject : ITicketDestination
    {
        public String Url { private set; get; }

        public String UserEMail { private set; get; }

        public ZendeskProject(String url, String userEMail, String userPassword)
        {
            Url = url;

            UserEMail = userEMail;

            UserPassword = userPassword;
        }

        #region UserPassword

        private SecureString _UserPassword;

        public String UserPassword
        {
            private set { SetUserPassword(value); }

            get { return GetUserPasword(); }
        }

        private String GetUserPasword()
        {
            var valuePtr = IntPtr.Zero;

            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(_UserPassword);

                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private void SetUserPassword(String value)
        {
            _UserPassword = new SecureString();

            value.ToList().ForEach(_UserPassword.AppendChar);
        }

        #endregion

        public IZendeskApi GetApi()
        {
            return new ZendeskApi(Url, UserEMail, UserPassword);
        }

        public Boolean CheckConnection()
        {
            try
            {
                var userResponse = GetApi().Users.GetCurrentUser();

                return userResponse.User != null;
            }
            catch (Exception exception)
            {
                //TODO log exception

                return false;
            }
        }
    }
}
