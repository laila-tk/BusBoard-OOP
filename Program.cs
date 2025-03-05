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

            string stopCode = UserInput.GetStopCode();
            try
            {
                var busArrivals = await TflClient.GetBusArrivals(stopCode);
                ArrivalManager.displayBusArrivals(busArrivals);
            }
            catch (Exception error)
            {
                Logger.Error($"Error: {error.Message}");
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}