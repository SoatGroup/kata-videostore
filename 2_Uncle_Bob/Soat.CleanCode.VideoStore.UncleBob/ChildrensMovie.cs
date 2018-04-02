namespace Soat.CleanCode.VideoStore.UncleBob
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title) { }

        public override decimal DetermineAmount(int daysRented)
        {
            var thisAmount = 1.5m;
            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5m;
            }

            return thisAmount;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
