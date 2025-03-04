using RestSharp;
using NLog;


namespace BusBoard
{

    public class TflClient : BaseRestClient
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public TflClient(): base("https://api.tfl.gov.uk/StopPoint"){ } 
        public async Task<List<StopPoint>> GetStopCodes(string coordinateString)
        {
            try
            {   
                string [] parts = coordinateString.Split(",");
                string longitude = parts[0].Trim();
                string latitude = parts[1].Trim();
                string endpoint= $"?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram";
                var response = await GetResponse<StopResponse>(endpoint);
                return response.StopPoints;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to fetch stopcodes from TFL API data");
                throw new Exception($"Error:{error.Message}");
            }
        }

        public async Task<List<Bus>> GetBusArrivals(string stopPoint)
        {
            try
            {
                string endpoint = $"{stopPoint}/Arrivals";
                var response = await GetResponse<List<Bus>>(endpoint);
                return response;
            }
            catch (Exception error)
            {
                Logger.Error("Unable to fetch bus arrivals from TFL API data");
                throw new Exception($"Error:{error.Message}");
            }
        }
    }
} 

