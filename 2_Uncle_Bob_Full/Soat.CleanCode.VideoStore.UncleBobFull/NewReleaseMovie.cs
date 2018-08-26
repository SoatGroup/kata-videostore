namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented) =>
            daysRented * 3;

        public override int DetermineFrequentRenterPoints(int daysRented) =>
            daysRented > 1 ? 2 : 1;
    }
}
