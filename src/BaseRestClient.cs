using NLog;
using RestSharp;

namespace BusBoard
{
    abstract class BaseRestClient
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected RestClient _restClient;

        protected BaseRestClient(string apiUrl)
        {
            _restClient = new RestClient(apiUrl);
        }

        protected async Task<T> GetResponse<T>(string endpoint)
        {
            try
            {
                Logger.Debug($"Sending request to endpoint: {endpoint}");
                var request = new RestRequest(endpoint);
                var response = await _restClient.GetAsync<T>(request);

                if (response == null)
                {
                    Logger.Error($"Failed to get a valid response from endpoint {endpoint}");
                    throw new Exception ($"API response from endpoint {endpoint} was unsuccesful");
                }

                Logger.Debug($"Retrieved response from endpoint {endpoint}");
                return response;
            }

            catch (Exception error)
            {
                Logger.Error(error,$"Error fetching API response from endpoint {endpoint},{error.Message}");
                throw new Exception($"Error fetching API response from endpoint {endpoint},{error.Message}");
            }
        }
    }
}