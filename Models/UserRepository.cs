using System.Linq;
using System.Collections.Generic;
using System;

namespace AG.TweeterApp
{
    public class UserRepository : IUserRepository
    {
        private IList<User> Users;

        public UserRepository(IList<User> users = null)
        {
            if (users == null)
            {
                //if no users then load it from default file
                var userStrings = FileManager.ReadUsersFromFile();
                if(userStrings == null || userStrings.Count == 0)
                {
                    Logger.LogError("Error reading strings from user file");                    
                }
                else
                {
                    Users = Utils.UserFollowerMapper(userStrings);                
                }
            }
            else
            {
                Users = users;
            }
        }

       
        public IList<User> GetAllUsers()
        {            
            return Users;
        }

        public User GetByName(string name)
        {
            return Users.FirstOrDefault(x=>x.Name == name);
        }


    }
}