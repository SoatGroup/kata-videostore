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

        public decimal DetermineAmount() => DetermineAmount(daysRented);

        private decimal DetermineAmount(int daysRented)
        {
            var rentalAmount = 0m;
            switch (movie.PriceCode)
            {
                case Movie.REGULAR:
                    rentalAmount += 2;
                    if (daysRented > 2)
                    {
                        rentalAmount += (daysRented - 2) * 1.5m;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    rentalAmount += daysRented * 3;
                    break;
                case Movie.CHILDREN:
                    rentalAmount += 1.5m;
                    if (daysRented > 3)
                    {
                        rentalAmount += (daysRented - 3) * 1.5m;
                    }
                    break;
            }

            return rentalAmount;
        }

        public int DetermineFrequentRenterPoints()
        {
            var bonusIsEarned = movie.PriceCode == Movie.NEW_RELEASE && daysRented > 1;
            if (bonusIsEarned)
                return 2;
            return 1;
        }
    }
}
