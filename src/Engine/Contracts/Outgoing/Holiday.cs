namespace Engine
{
    public class Holiday
    {
        public required Flight Flight { get; init; }
        public required Hotel Hotel { get; init; }
        public string TotalPrice => $"£{Flight.Price + Hotel.Price}.00";
    }
}