using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace TwitterClient.Helpers
{

    public static class CustomHtmlHelper
    {
        private const string urlRegEx = @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)";

        public static MvcHtmlString DisplayTweet(this HtmlHelper htmlHelper, Model.TweetModel tweet)
        {
            string result = ReplaceUrlsWithLinks(tweet.Text);
            result += AddDateTime(tweet.CreatedDateTime);
            return MvcHtmlString.Create(result);
        }

        private static string ReplaceUrlsWithLinks(string input)
        {
            Regex rx = new Regex(urlRegEx);
            string result = rx.Replace(input, delegate(Match match)
            {
                string url = match.ToString();
                return String.Format("<a target='_blank' href=\"{0}\">{0}</a>", url);
            });
            return result;
        }

        private static string AddDateTime(DateTime dateTime)
        {
            return String.Format("<br/>{0}", dateTime);
        }
       
    }
}