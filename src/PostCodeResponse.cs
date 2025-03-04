namespace BusBoard
{

  public class PostCodeResponse
  {
    public required int Status { get; set; }
    public required Result Result { get; set; }
  }

  public class Result
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
  }
}
