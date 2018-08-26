namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class ChildrenMovie : Movie
    {
        public ChildrenMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented)
        {
            if (daysRented > 3)
                return 1.5m + (daysRented - 3) * 1.5m;
            else
                return 1.5m;
        }

        public override int DetermineFrequentRenterPoints(int daysRented) => 1;
    }
}
