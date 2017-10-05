using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AG.TweeterApp
{
    ///Singleton Class to store app setting read from app.config
    public sealed class AppSettings
    {        
        public static string DefaultLoggerPath {get;set;}        
        public static string UserFilePath {get;set;}       
        public static string TweetFilePath {get;set;}   
        public static string FileDelimiterFollows {get;set;}       
        public static string FileDelimiterTweet {get;set;}       
        

        static readonly AppSettings instance = new AppSettings();
        AppSettings(){}
        static AppSettings()
        {
            //todo load from setting.json file
            var basePath = Directory.GetCurrentDirectory();
            DefaultLoggerPath = $"{basePath}\\logger.txt";
            UserFilePath = $"{basePath}\\inputfiles\\User.txt";
            TweetFilePath = $"{basePath}\\inputfiles\\Tweet.txt";
            FileDelimiterFollows = "follows";
            FileDelimiterTweet = ">";
        }
        
    }
}