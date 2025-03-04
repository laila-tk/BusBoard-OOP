using RestSharp;
using NLog;


namespace BusBoard
{

    public class TflClient : BaseRestClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public TflClient(): base("https://api.tfl.gov.uk/StopPoint"){ } 
        public async Task<StopResponse> GetStopCodes(string coordinatesstring)
        {
            try
            {   
                string [] parts = coordinatesstring.Split(",");
                string longitude = parts[0];
                string latitude = parts[1];
                string endpoint= $"?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram";
                var response = await GetResponse<StopResponse>(endpoint);
                return response;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to fetch stopcodes from TFL API data");
                throw new Exception($"Error:{error.Message}");
            }
        }

        // public static async Task<List<Bus>> GetBusArrivals(string stopCode)
        // {
        //     try
        //     {
        //         var request = new RestRequest($"{stopCode}/Arrivals");
        //         Logger.Info($"Fetching arrival data for stopcode {stopCode}");
        //         var arrivals = await stopPointClient.GetAsync<List<Bus>>(request);
        //         if (arrivals?.Count == 0)
        //         {
        //             Logger.Info($"No Bus Arrivals for stopcode {stopCode}");
        //         }
        //         return arrivals;
        //     }
        //     catch (Exception error)
        //     {
        //         Logger.Error("Unable to fetch bus arrivals from TFL API data");
        //         throw new Exception($"Error:{error.Message}");
        //     }
        // }
    }
} 

