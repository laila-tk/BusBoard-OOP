using NLog;
using NLog.Config;
using NLog.Targets;

namespace BusBoard
{
    public class BusBoard
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
                PostCodeClient postcodeclient = new PostCodeClient();
                Coordinates coordinates = await postcodeclient.GetCoordinates(postCode);
                string coordinatesstring = $"{coordinates.Longitude},{coordinates.Latitude}";
                TflClient tflclient = new TflClient();
                var response = await tflclient.GetStopCodes(coordinatesstring);
                Console.WriteLine(response);
    
            }
            catch (Exception error)
            {
                Logger.Error($"Error: {error.Message}");
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}