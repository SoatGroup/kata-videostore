namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public abstract class Movie
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

        public abstract decimal DetermineAmount(int daysRented);
        public abstract int DetermineFrequentRenterPoints(int daysRented);
    }
}
