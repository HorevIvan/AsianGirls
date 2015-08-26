using System;
using ZendeskApi_v2;

namespace Zendesk
{
    public class ZendeskRepository : IZendeskRepository
    {
        public String Url { private set; get; }

        public String Login { private set; get; }

        public String Password { private set; get; }

        public ZendeskRepository(String url, String login, String password)
        {
            Url = url;

            Login = login;

            Password = password;
        }

        protected IZendeskApi GetApi()
        {
            return new ZendeskApi(Url, Login, Password);
        }
    }
}