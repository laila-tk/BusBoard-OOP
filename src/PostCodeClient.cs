using RestSharp;
using NLog;

namespace BusBoard
{
    public class PostCodeClient : BaseRestClient 
    
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        
        public PostCodeClient(): base("https://api.postcodes.io/")
        {

        }

        public async Task<(double Latitude, double Longitude)> GetCoordinates(string postcode)
        {
            try
            {
                string endpoint = $"/postcodes/{postcode}";

                var response = await GetResponse<PostCodeResponse>(endpoint);
                return (response.Result);
            }
            
            catch (Exception error)
            {
                Logger.Error("Unable to fetch coordinates from PostCode API data");
                throw new Exception($"Error:{error.Message}");
            }
        }
    }
}
