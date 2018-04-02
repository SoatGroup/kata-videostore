namespace Soat.CleanCode.VideoStore.UncleBob
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int   _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie      = movie;
            _daysRented = daysRented;
        }

        public string Title => _movie.Title;

        public decimal DetermineAmount() => _movie.DetermineAmount(_daysRented);

        public int DetermineFrequentRenterPoints() => _movie.DetermineFrequentRenterPoints(_daysRented);
    }
}
