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

        public decimal DetermineAmount()
        {
            var rentalAmount = 0m;
            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    rentalAmount += 2;
                    if (DaysRented > 2)
                    {
                        rentalAmount += (DaysRented - 2) * 1.5m;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    rentalAmount += DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    rentalAmount += 1.5m;
                    if (DaysRented > 3)
                    {
                        rentalAmount += (DaysRented - 3) * 1.5m;
                    }
                    break;
            }

            return rentalAmount;
        }

        public int DetermineFrequentRenterPoints()
        {
            var bonusIsEarned = Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1;
            if (bonusIsEarned)
                return 2;
            return 1;
        }
    }
}
