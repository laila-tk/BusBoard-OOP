namespace BusBoard
{
    class Bus
    {
        public required string DestinationName { get; set; }
        public required string LineName { get; set; }
        public required int TimeToStation { get; set; }
    }
}