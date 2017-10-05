using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace AG.TweeterApp
{
    public interface ITweetRepository
    {
        IList<Tweet> GetAllTweets();
        IList<Tweet> GetTweetsByUserName(string userName);
    }
}