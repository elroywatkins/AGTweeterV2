using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AG.TweeterApp
{
    public class Program
    {
        //public static IConfigurationRoot AppConfig { get; set; }
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Tweeter App From Console");
            try
            {
                IUserRepository userRepo = new UserRepository();
                ITweetRepository tweetRepo = new TweetRepository();
                TweetManager tweetManager = new TweetManager(userRepo,tweetRepo);
                tweetManager.PrintTweets();
                Console.WriteLine("Tweeter App Finished From Console, press any key to close");
            }
            catch(Exception ex)
            {
                Console.WriteLine("A critical application error occurred. Please see the logs for further detail");
                Logger.LogError($"A critical application error occurred detailed as follows: {ex.Message}.Stack Trace: {ex.StackTrace}");
            }
            Console.ReadKey();
        }

        // public static void InitialiseConfigBuilder()
        // {
        //     var AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(AssemblyPath)
        //         .AddJsonFile("appsettings.json");
        //     AppConfig = builder.Build();                 
        // }


        // public static void Main(string[] args)
        // {
        //     // create service collection
        //     var serviceCollection = new ServiceCollection();
        //     ConfigureServices(serviceCollection);
    
        //     // create service provider
        //     var serviceProvider = serviceCollection.BuildServiceProvider();
    
        //     // entry to run app
        //     serviceProvider.GetService<TweeterApp>().Run();
        // }
    
        // private static void ConfigureServices(IServiceCollection serviceCollection)
        // {
        //     //add logging
        //     serviceCollection.AddSingleton(new LoggerFactory().AddConsole().AddDebug());
        //     serviceCollection.AddLogging(); 
    
        //     // add services
        //     serviceCollection.AddTransient<IAppService, AppService>();
    
        //     // add app
        //     serviceCollection.AddTransient<TweeterApp>();
        // }

        
    }
}
