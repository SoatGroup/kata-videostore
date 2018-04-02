using System;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public class Pricer : IPricer
    {
        public IPrice GetPrice(Movie movie)
        {
            if (movie.ReleaseType == ReleaseType.New) {
                return Price.CreateNewRelease();
            }

            switch (movie.Category) {
                case MovieCategory.Children:
                    return Price.CreateChildren();

                case MovieCategory.Regular:
                    return Price.CreateRegular();

                default:
                    throw new ArgumentOutOfRangeException(nameof(movie), movie.Category, "Invalid movie category");
            }
        }
    }
}
