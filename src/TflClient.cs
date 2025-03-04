using RestSharp;
using NLog;


namespace BusBoard
{

    class TflClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly RestClient stopPointClient = new RestClient(new RestClientOptions("https://api.tfl.gov.uk/StopPoint"));
        public static async Task<List<string>> GetStopCodes(Coordinates coordinates)
        {
            try
            {
                var request = new RestRequest($"?lat={coordinates.latitude}&lon={coordinates.longitude}&stopTypes=NaptanPublicBusCoachTram");
                Logger.Info($"Fetching stopcodes for latitude ={coordinates.latitude} & longitude={coordinates.longitude}");
                var stopCodes = await stopPointClient.GetAsync<List<string>>(request);
                if (stopCodes?.Count == 0)
                {
                    Logger.Info($"No stop codes available for latitude ={coordinates.latitude} & longitude={coordinates.longitude}");
                }
                return stopCodes;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to fetch stopcodes from TFL API data");
                throw new Exception($"Error:{error.Message}");
            }
        }

        public static async Task<List<Bus>> GetBusArrivals(string stopCode)
        {
            try
            {
                var request = new RestRequest($"{stopCode}/Arrivals");
                Logger.Info($"Fetching arrival data for stopcode {stopCode}");
                var arrivals = await stopPointClient.GetAsync<List<Bus>>(request);
                if (arrivals?.Count == 0)
                {
                    Logger.Info($"No Bus Arrivals for stopcode {stopCode}");
                }
                return arrivals;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to fetch bus arrivals from TFL API data");
                throw new Exception($"Error:{error.Message}");
            }
        }
    }
}
