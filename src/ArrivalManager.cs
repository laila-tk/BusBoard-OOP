using NLog;

namespace BusBoard
{
    class ArrivalManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static void DisplayBusArrivals(List<Bus> busArrivals)
        {
            try
            {
                var sortedBusArrivals = busArrivals.OrderBy(bus => bus.TimeToStation).Take(5).ToList();

                if (sortedBusArrivals.Count == 0)
                {
                    Console.WriteLine("There are no bus arrivals for the given stop");
                    Logger.Warn("No bus arrivals found");
                    throw new Exception("No bus arrivals found");
                }

                int index = 1;
                foreach (var bus in sortedBusArrivals)
                {
                    Console.WriteLine($"\nBus {index}");
                    Console.WriteLine($"Destination: {bus.DestinationName}");
                    Console.WriteLine($"Route: {bus.LineName}");
                    Console.WriteLine($"Time To Station: {bus.TimeToStation / 60} min");
                    index++;
                }
            }
            catch (Exception error)
            {
                Logger.Error($"Unable to display bus arrivals: {error}");
                throw new Exception($"Error displaying bus arrivals: {error}");
            }
        }
    }
}