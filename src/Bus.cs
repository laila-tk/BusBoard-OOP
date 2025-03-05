namespace BusBoard
{
    class Bus
    {
        public required string destinationName { get; set; }
        public required string lineName { get; set; }
        public required int timeToStation { get; set; }
    }
}