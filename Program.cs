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
                string coordinateString = $"{coordinates.Longitude},{coordinates.Latitude}";
                TflClient tflclient = new TflClient();
                List<StopPoint> stoppoints = await tflclient.GetStopCodes(coordinateString);
                foreach (var stop in stoppoints)
                {
                    string stoppoint = "stop";
                    List<Bus> arrivals = await tflclient.GetBusArrivals(stoppoint);
                    ArrivalManager.DisplayBusArrivals(arrivals);
                }


            }
            catch (Exception error)
            {
                Logger.Error($"Error: {error.Message}");
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}