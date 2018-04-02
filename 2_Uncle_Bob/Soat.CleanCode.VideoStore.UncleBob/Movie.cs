namespace Soat.CleanCode.VideoStore.UncleBob
{
    public abstract class Movie
    {
        public string Title { get; }

        protected Movie(string title)
        {
            Title = title;
        }

        public abstract decimal DetermineAmount(int daysRented);

        public abstract int DetermineFrequentRenterPoints(int daysRented);
    }
}
