namespace BusBoard
{
    class StopPointData
    {
        public required string NaptanId { get; set; }
        public required string CommonName { get; set; }
    }

    class StopPoint
    {
        public string NaptanId { get; }
        public string CommonName { get; }
        public StopPoint(string naptanid, string commonname)
        {
            NaptanId = naptanid;
            CommonName = commonname;
        }

    }

}
