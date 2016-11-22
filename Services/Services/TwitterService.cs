using Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;


namespace Services
{

    public class TwitterService
    {
        private RestClient _client;
        public TwitterService(string consumerKey,string consumerSecret,string accessToken,string accessTokenSecret)
        {
            _client = new RestClient("https://api.twitter.com/1.1/");

            _client.Authenticator = OAuth1Authenticator.ForProtectedResource(

            consumerKey, consumerSecret, accessToken, accessTokenSecret

            );

        }

        public List<TweetModel> GetLatestTweets(string username, int count)
        {
            var restRequest = new RestRequest("statuses/user_timeline.json", Method.GET);
            restRequest.AddParameter("screen_name", username);
            restRequest.AddParameter("count", count);

            var result = _client.Execute(restRequest);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new Exception(result.ErrorMessage);

            dynamic tweets = SimpleJson.DeserializeObject(result.Content);
            var tweetList = new List<TweetModel>();
            //TODO: use mapper instead of looping
            foreach (var tweet in tweets)
            {
                tweetList.Add(new TweetModel
                {
                    Text = tweet["text"].ToString(),

                    CreatedDateTime = DateTime.ParseExact(tweet["created_at"], "ddd MMM dd HH:mm:ss +ffff yyyy", new System.Globalization.CultureInfo("en-US"))
                });
            }
            return tweetList;
        }

    }
}
