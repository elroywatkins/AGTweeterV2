using System.Linq;
using System.Collections.Generic;
using System;

namespace AG.TweeterApp
{
    public static partial class Utils
    {
        public static IList<User> UserFollowerMapper(IDictionary<int,string> userDictionary)
        {                                   
            var resultUserList = new List<User>();
            string delimiter = AppSettings.FileDelimiterFollows; //todo read from settings
            int lineNumber = 0;
            var itemString = "";
            foreach(KeyValuePair<int,string> userItem in userDictionary)
            {                                  
                lineNumber = userItem.Key;
                itemString = userItem.Value;
                // find delimiter postion
                var chrIdx = itemString.IndexOf(delimiter);     
                if (chrIdx == -1)
                {
                    Logger.LogError("Delimeter for users not found in file");
                    continue;
                }
                //extract user name
                string userName = itemString.Substring(0,chrIdx-1).Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    Logger.LogError("No username in file");
                    continue;
                }

                //if user already exists only add his followers
                var existingUser = resultUserList.FirstOrDefault(x=>x.Name.Trim()==userName);                   
                //extract the followers from the rest of the string                
                var strLength = itemString.Length-chrIdx-delimiter.Length-1;                
                string followersStringList = itemString.Substring(chrIdx+delimiter.Length+1,strLength);
                var followers =  GetFollowersFromList(followersStringList);                    

                //add or update users                
                if (existingUser == null)
                {   
                    var user = new User()
                    {
                        Name = userName,
                        Following = followers
                    };
                    resultUserList.Add(user);
                }
                else
                {
                    existingUser.Following = UpdateFollowers(existingUser.Following,followers);
                }                                                                              
            }

            // add followers as users
            var uniqueFollowers = GetUniqueFollowersNotExistingUsers(resultUserList);
            resultUserList.AddRange(uniqueFollowers);
            return resultUserList;
        }

        //Get all the followers who do not appear in the user list
        private static IList<User> GetUniqueFollowersNotExistingUsers(List<User> userList)
        {            
            //extract all followers
            var allFollowers = new List<User>();
            foreach(var user in userList)
            {
                foreach(var follower in user.Following)
                {
                    allFollowers.Add(new User(){Name=follower.Name});
                }                
            }            
            
           // var followersToAdd = allFollowers.Where(x=>!userList.Any(y => y.Name == x.Name)).ToList();
            var followersToAdd = allFollowers.Where(x=>!userList.Any(y => y.Name == x.Name))
            .GroupBy(x => x.Name).Select(g=>g.FirstOrDefault()).ToList();
            return followersToAdd;
        }

        private static IList<Follower> UpdateFollowers(IList<Follower> existingFollowers, IList<Follower> followersToAdd)
        {            
            foreach(var follower in followersToAdd)
            {
                if (!existingFollowers.Any(x=>x.Name==follower.Name))
                {
                    existingFollowers.Add(new Follower(){Name = follower.Name});
                }
            }
            return existingFollowers;
        }

        private static IList<Follower> GetFollowersFromList(string followersStringList)
        {
            var resultList = new List<Follower>();
            foreach(var follower in followersStringList.Split(", ").ToList())
            {
                resultList.Add(new Follower(){Name=follower.Trim()});
            }
            return resultList;
            
        }
    }
}

