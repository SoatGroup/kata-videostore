namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Rental
    {
        private readonly int daysRented;
        private readonly Movie movie;

        public string Title => movie.Title;

        public Rental(Movie movie, int daysRented)
        {
            this.movie      = movie;
            this.daysRented = daysRented;
        }

        public decimal DetermineAmount() =>
            movie.DetermineAmount(daysRented);

        public int DetermineFrequentRenterPoints() =>
            movie.DetermineFrequentRenterPoints(daysRented);
    }
}
