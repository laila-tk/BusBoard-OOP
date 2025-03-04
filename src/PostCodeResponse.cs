namespace BusBoard
{

  class PostCodeResponse
  {
    public required int Status { get; set; }
    public required Result Result { get; set; }
  }

  class Result
  {
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
  }
}
