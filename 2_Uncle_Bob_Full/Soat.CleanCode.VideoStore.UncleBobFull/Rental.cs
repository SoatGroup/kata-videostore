namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Rental
    {
        public int DaysRented { get; }
        public Movie Movie { get; }

        public string Title => Movie.Title;

        public Rental(Movie movie, int daysRented)
        {
            Movie      = movie;
            DaysRented = daysRented;
        }
    }
}
