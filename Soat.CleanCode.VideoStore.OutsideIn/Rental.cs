namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public class Rental : IRental
    {
        public Movie Movie { get; }
        public Duration Duration { get; }

        public Rental(Movie movie, Duration duration)
        {
            Movie    = movie;
            Duration = duration;
        }
    }
}
