using System;
using System.Collections.Generic;
using System.IO;

namespace AG.TweeterApp
{
    //Class Responsible for handling reading of files
    public class FileManager
    {
        public static IDictionary<int,string> ReadUsersFromFile()
        {
            var userFilePath = AppSettings.UserFilePath;
            return ReadFileToStringList(userFilePath);
        }

        public static IDictionary<int,string> ReadTweetsFromFile()
        {
            var tweetFilePath = AppSettings.TweetFilePath;
            return ReadFileToStringList(tweetFilePath);
        }
        
        public static IDictionary<int,string> ReadFileToStringList(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Logger.LogError($"The file '{filePath}' does not exist");                                
            }

            var resultDictionary = new Dictionary<int,string>();
            try
            {            
                string[] lines = File.ReadAllLines(filePath,System.Text.Encoding.ASCII); 
                int i = 0;                   
                foreach(var line in lines)
                {   
                    //skip empty lines
                    if (!string.IsNullOrEmpty(line))              
                    {
                        resultDictionary.Add(i,line);
                        i++;
                    }
                }                
            }
            catch (Exception ex)
            {
                Logger.LogError($"An error occurred reading the file '{filePath}' : {ex.Message}");                
            }
            if (resultDictionary.Count > 0)
            {
                Logger.LogInformation($"File successfully loaded, file '{filePath}'");                
            }
            else
            {
                Logger.LogError($"No records where found reading the file  '{filePath}'");                
            }
            return resultDictionary;
        }
    }
}