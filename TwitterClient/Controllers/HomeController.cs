using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClient.Helpers;

namespace TwitterClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLatestTweets(string username)
        {
                var twitterService = new TwitterService(WebConfigHelper.ConsumerKey, WebConfigHelper.ConsumerSecret, WebConfigHelper.AccessToken, WebConfigHelper.AccessTokenSecret);
                var tweets = twitterService.GetLatestTweets(username, 100);
                return PartialView("_Grid", tweets);
           
        }
    }
}