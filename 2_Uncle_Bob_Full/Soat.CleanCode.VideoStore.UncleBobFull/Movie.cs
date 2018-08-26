namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Movie
    {
        public const int REGULAR     = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN    = 2;

        public int PriceCode { get; set; }
        public string Title { get; }

        public Movie(string title, int priceCode)
        {
            Title     = title;
            PriceCode = priceCode;
        }

        public decimal DetermineAmount(int daysRented)
        {
            var rentalAmount = 0m;
            switch (PriceCode)
            {
                case REGULAR:
                    rentalAmount += 2;
                    if (daysRented > 2)
                    {
                        rentalAmount += (daysRented - 2) * 1.5m;
                    }
                    break;
                case NEW_RELEASE:
                    rentalAmount += daysRented * 3;
                    break;
                case CHILDREN:
                    rentalAmount += 1.5m;
                    if (daysRented > 3)
                    {
                        rentalAmount += (daysRented - 3) * 1.5m;
                    }
                    break;
            }

            return rentalAmount;
        }
    }
}
