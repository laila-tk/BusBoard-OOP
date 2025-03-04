using RestSharp;

namespace BusBoard
{
    class PostCodeClient : BaseRestClient

    {
        public PostCodeClient() : base("https://api.postcodes.io/") { }

        public async Task<Coordinates> GetCoordinates(string postcode)
        {
            try
            {
                string endpoint = $"/postcodes/{postcode}";

                var response = await GetResponse<PostCodeResponse>(endpoint);
                return new Coordinates(response.Result.Longitude, response.Result.Latitude);
            }

            catch (Exception error)
            {
                throw new Exception($"Error:{error.Message}");
            }
        }
    }
}
