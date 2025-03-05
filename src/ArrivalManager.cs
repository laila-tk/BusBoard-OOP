namespace BusBoard
{
    class ArrivalManager
    {
        private static List<Bus> sortBusArrivals(List<Bus> busArrivals)
        {
            return busArrivals.OrderBy(bus => bus.timeToStation).ToList();
        }

        private static List<Bus> getFirstFiveArrivals(List<Bus> busArrivals)
        {
            return busArrivals.Take(5).ToList();
        }

        public static void displayBusArrivals(List<Bus> busArrivals)
        {
            var sortedArrivals = sortBusArrivals(busArrivals);
            var firstFiveArrivals = getFirstFiveArrivals(sortedArrivals);
            int index = 1;
            if (firstFiveArrivals.Count == 0)
            {
                Console.WriteLine("There are no bus arrivals for the given stopcode");
            }
            else
            {
                foreach (var bus in firstFiveArrivals)
                {
                    Console.WriteLine($"\nBus {index}");
                    Console.WriteLine($"Destination: {bus.destinationName}");
                    Console.WriteLine($"Route: {bus.lineName}");
                    Console.WriteLine($"Time To Station: {bus.timeToStation / 60} min");
                    index++;
                }
            }
        }
    }
}