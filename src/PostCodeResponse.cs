namespace BusBoard
{

  class PostCodeResponse
  {
    public required PostCodeResult Result { get; set; }
  }

  class PostCodeResult
  {
    public required double Longitude { get; set; }
    public required double Latitude { get; set; }
  }

}
