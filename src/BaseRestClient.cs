using RestSharp;

namespace BusBoard
{

    abstract class BaseRestClient
    {
        protected RestClient _restClient;

        protected BaseRestClient(string apiUrl)
        {
            _restClient = new RestClient(apiUrl);
        }

        protected async Task<T> GetResponse<T>(string endpointparameter)
        {
            try
            {
                var request = new RestRequest(endpointparameter);
                var response = await _restClient.GetAsync<T>(request);

                if (response == null)
                {
                    throw new Exception($"API Error: Unable to fetch response");
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