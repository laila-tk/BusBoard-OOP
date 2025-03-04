namespace BusBoard
{
    class StopPoint
    {
        public string NaptanId { get; }
        public String CommonName{get;}

        public StopPoint(string naptanid, string commonname)
        {
            NaptanId = naptanid;
            CommonName = commonname;
        }

    }
}