namespace Soat.CleanCode.VideoStore.UncleBob
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented)
        {
            return daysRented * 3.0m;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1
                       ? 2
                       : 1;
        }
    }
}
