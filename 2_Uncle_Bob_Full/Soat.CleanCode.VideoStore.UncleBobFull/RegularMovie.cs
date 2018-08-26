namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented)
        {
            if (daysRented > 2)
                return 2m + (daysRented - 2) * 1.5m;
            else
                return 2m;
        }

        public override int DetermineFrequentRenterPoints(int daysRented) => 1;
    }
}
