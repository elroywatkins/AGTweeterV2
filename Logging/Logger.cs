using Microsoft.Extensions.Logging;
namespace AG.TweeterApp
{
    public static class Logger
    {
        //todod Convert this class to use the standard Microsoft Logging implementation
        public static void LogInformation(string message)
        {
            System.Console.WriteLine(message);
        }
        public static void LogWarning(string message)
        {
            System.Console.WriteLine(message);
        }  

        public static void LogError(string message)
        {
            System.Console.WriteLine(message);
        }          
    }    
}