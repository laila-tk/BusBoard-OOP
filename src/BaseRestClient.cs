using RestSharp;

namespace BusBoard{

    public abstract class BaseRestClient
    {
        protected RestClient _restClient;

        protected BaseRestClient(string apiUrl)
        {
           _restClient = new RestClient(apiUrl);
        }

        protected async Task<T> GetResponse<T>(string endpoint)
        {
            try
            {
                var request = new RestRequest(endpoint);
                var response = await _restClient.GetAsync<T>(request);

                if(response == null)
                {
                    throw new Exception ($"API Error: Response is null");
                }
                return response;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}