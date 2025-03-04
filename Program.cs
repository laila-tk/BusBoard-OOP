using NLog;
using NLog.Config;
using NLog.Targets;

namespace BusBoard
{
    class BusBoard
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static async Task Main()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Users\LaiKha\Training\BusboardOOP\Busboard.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target); config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            string postCode = UserInput.GetPostCode();
            Console.WriteLine(postCode);
            try
            {
                var (longitude, latitude)= await PostCodeClient.GetCoordinates(postCode);
                Console.WriteLine(longitude,latitude);
    
            }
            catch (Exception error)
            {
                Logger.Error($"Error: {error.Message}");
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}