using RestSharp;
using NLog;

namespace BusBoard
{

    class TflClient : BaseRestClient
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TflClient() : base("https://api.tfl.gov.uk/StopPoint") { }
        public async Task<List<StopPoint>> GetStopPoints(Coordinates coordinates)
        {
            string endPoint = $"?lat={coordinates.Latitude}&lon={coordinates.Longitude}&stopTypes=NaptanPublicBusCoachTram";
            try
            {   
                Logger.Info($"Passing endpoint {endPoint} for Stop Points using coordinates lat={coordinates.Latitude}&lon={coordinates.Longitude}");
                var response = await GetResponse<TflStopPointsResponse>(endPoint);
                return response.StopPoints.Select(stoppoint=> new StopPoint(stoppoint.NaptanId,stoppoint.CommonName)).ToList();
            }
            catch (Exception error)
            {
                Logger.Error($"Error fetching stop points for coordinates lat={coordinates.Latitude}&lon={coordinates.Longitude},{error.Message}");
                throw new Exception($"Error fetching stop points for coordinates lat={coordinates.Latitude}&lon={coordinates.Longitude},{error.Message}");
            }
        }

        public async Task<List<Bus>> GetBusArrivals(StopPoint stopPoint)
        {
            string endPoint = $"{stopPoint.NaptanId}/Arrivals";
            try
            {
                Logger.Info($"Passing endpoint {endPoint} for bus arrivals at stop point {stopPoint.NaptanId}");
                var response = await GetResponse<List<Bus>>(endPoint);
                return response;
            }
            catch (Exception error)
            {
                Logger.Error($"Error fetching bus arrivals for stop point {stopPoint.NaptanId},{error.Message}");
                throw new Exception($"Error fetching bus arrivals for stop point {stopPoint.NaptanId},{error.Message}");
            }
        }
    }
}

