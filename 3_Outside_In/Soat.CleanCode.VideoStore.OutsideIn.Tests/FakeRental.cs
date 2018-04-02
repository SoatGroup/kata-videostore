namespace Soat.CleanCode.VideoStore.OutsideIn.Tests
{
    public class FakeRental : IRental
    {
        public Movie Movie { get; set; }
        public Duration Duration { get; }
    }
}
