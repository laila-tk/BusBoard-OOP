namespace BusBoard
{
  public class Coordinates
  {
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    public Coordinates(double longitude, double latitude)
    {
      Longitude = longitude;
      Latitude = latitude;

    }
  }
}