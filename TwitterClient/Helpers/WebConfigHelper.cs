using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClient.Helpers
{
    public class WebConfigHelper
    {
        public static string ConsumerKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"]; }
        }

        public static string ConsumerSecret
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ConsumerSecret"]; }

        }

        public static string AccessToken
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["AccessToken"]; }
        }

        public static string AccessTokenSecret
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["AccessTokenSecret"]; }

        }
    }
}