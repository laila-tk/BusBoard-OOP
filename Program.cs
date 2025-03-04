
namespace BusBoard
{
    class BusBoard
    {
        public static async Task Main()
        {
            string postCode = UserInput.GetPostCode();
            Console.WriteLine(postCode);
            try
            {
                PostCodeClient postcodeclient = new PostCodeClient();
                Coordinates coordinates = await postcodeclient.GetCoordinates(postCode);
                string coordinateString = $"{coordinates.Longitude},{coordinates.Latitude}";

                TflClient tflclient = new TflClient();
                List<StopPoint> stoppoints = await tflclient.GetStopCodes(coordinateString);
                foreach (var stop in stoppoints)
                { 
                    Console.WriteLine($"\n{stop.CommonName}");
                    string stoppoint = $"{stop.NaptanId}";
                    List<Bus> arrivals = await tflclient.GetBusArrivals(stoppoint);
                    ArrivalManager.DisplayBusArrivals(arrivals);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }


        }
    }
}