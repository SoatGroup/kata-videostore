namespace Soat.CleanCode.VideoStore.UncleBob
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented)
        {
            var thisAmount = 2m;
            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5m;
            }

            return thisAmount;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
