using RestSharp;
using NLog;


namespace BusBoard
{

    class TflClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly RestClient stopPointClient = new RestClient(new RestClientOptions("https://api.tfl.gov.uk/StopPoint"));
        public static async Task<List<Bus>> GetBusArrivals(string stopCode)
        {
            try
            {
                var request = new RestRequest($"{stopCode}/Arrivals");
                Logger.Info($"Fetching arrival data for stopcode {stopCode}");
                var arrivals = await stopPointClient.GetAsync<List<Bus>>(request);
                if (arrivals?.Count==0)
                {   
                    Logger.Info($"No Bus Arrivals for stopcode {stopCode}");
                }
                return arrivals;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to Fetch API data");
                throw new Exception($"Error:{error.Message}");
            }
        }
    }
}
