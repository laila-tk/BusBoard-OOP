using RestSharp;
using NLog;

namespace BusBoard
{
    class PostCodeClient : BaseRestClient
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public PostCodeClient() : base("https://api.postcodes.io/") { }

        public async Task<Coordinates> GetCoordinates(string postCode)
        {
            string endPoint = $"/postcodes/{postCode}";
            try
            {
                Logger.Info($"Passing endpoint {endPoint} request for postcode {postCode}");
                var response = await GetResponse<PostCodeResponse>(endPoint);
                return new Coordinates(response.Result.Longitude, response.Result.Latitude);
            }
            catch (Exception error)
            {
                Logger.Error($"Error fetching coordinates for postcode {postCode},{error.Message}");
                throw new Exception($"Error fetching coordinates for postcode {postCode},{error.Message}");
            }
        }
    }
}
