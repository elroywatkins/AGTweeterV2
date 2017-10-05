using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;


namespace AG.TweeterApp
{
    public class TweetManager
    {
        public IUserRepository UserRepository;
        public ITweetRepository TweetRepository;
         

        public TweetManager(IUserRepository userRepo,ITweetRepository tweetRepo)
        {            
            if (userRepo == null)
            {
                Logger.LogError("Users are required for tweet proccessing");
                return;
            }            

            if (tweetRepo == null)
            {
                Logger.LogError("tweets are required for tweet proccessing");
                return;
            }

            UserRepository = userRepo;
            TweetRepository = tweetRepo;
        }

        public void PrintTweets()
        {
            Console.WriteLine("Printing Output");
            Console.WriteLine("===============");
            var userName = "";

            foreach(var user in  UserRepository.GetAllUsers().OrderBy(x=>x.Name))
            {
                userName = user.Name;
                Console.WriteLine(userName);
                Console.WriteLine("----------------");

                var userTweets = TweetRepository.GetTweetsByUserName(userName);
                //if following is not null process their tweets
                if (user.Following != null)
                {
                    IList<Tweet> followerTweets = new List<Tweet>();
                    foreach(var follower in user.Following)
                    {
                        foreach(var tweet in TweetRepository.GetTweetsByUserName(follower.Name))
                        {
                            followerTweets.Add(tweet);                    
                        }
                    }
                    
                    //add follower tweets
                    if (followerTweets.Count > 0)          
                    {
                        foreach(var tweet in followerTweets)
                        {
                            userTweets.Add(tweet);
                        }                     
                    }
                    
                }

                foreach(var tweet in userTweets.OrderBy(x=>x.MessageOrder))
                {
                    Console.WriteLine($"    @{tweet.User.Name}: {tweet.Message}");                    
                }
                Console.WriteLine("  ");
            }


        }
    }
}