using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;

namespace BusBoard
{
    class BusBoard
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static async Task Main()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = "${basedir}/Busboard.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            try
            {
                Logger.Info("Program started");

                var userInput = new UserInput();
                string postCode = userInput.GetPostCode();
                Logger.Info($"User entered postcode {postCode}");

                var postcodeclient = new PostCodeClient();
                Coordinates coordinates = await postcodeclient.GetCoordinates(postCode);
                Logger.Info($"Coordinates retrieved: Longitude:{coordinates.Longitude}, Latitude:{coordinates.Latitude}");

                var tflclient = new TflClient();
                List<StopPoint> stopPoints = await tflclient.GetStopPoints(coordinates);
                Logger.Info($"{stopPoints.Count} stop points retreived near the postcode {postCode}");

                foreach (var stop in stopPoints)
                {
                    Console.WriteLine($"\n{stop.CommonName}");

                    Logger.Info($"Fetching bus arrivals for stop: {stop.NaptanId}");
                    List<Bus> arrivals = await tflclient.GetBusArrivals(stop);
                    ArrivalManager.DisplayBusArrivals(arrivals);
                }

                Logger.Info("Program ended");
            }
            catch (Exception error)
            {
                Logger.Error(error, "Unable to process bus arrivals");
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}