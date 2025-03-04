using RestSharp;

namespace BusBoard{

    public abstract class BaseRestClient
    {
        protected RestClient _restClient;

        public void BaseClient(string apiUrl)
        {
           _restClient = new RestClient(apiUrl);
        }

        protected async Task<T> GetResponse<T>(string endpoint)
        {
            try
            {
                var request = new RestRequest(endpoint);
                var response = await _restClient.GetAsync<T>(request);

            if(response.Data == null)
            {
                throw new Exception ($"API Error: {error}");
            }
            return response.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}