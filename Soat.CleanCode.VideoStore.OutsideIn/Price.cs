using Soat.CleanCode.VideoStore.OutsideIn.Fees;
using Soat.CleanCode.VideoStore.OutsideIn.Points;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public class Price : IPrice
    {
        private static FeesBuilder Fees() => new FeesBuilder();

        public static Price CreateChildren()
        {
            return new Price(PriceCode.Children,
                             Fees().FirstFlat(1.5m)
                                   .During(3)
                                   .ThenLinear(1.5m),
                             new RegularPoints());
        }

        public static Price CreateNewRelease() {
            return new Price(PriceCode.NewRelease,
                             Fees().Linear(3m),
                             new BonusPoints());
        }

        public static Price CreateRegular() {
            return new Price(PriceCode.Regular,
                             Fees().FirstFlat(2m)
                                   .During(2)
                                   .ThenLinear(1.5m),
                             new RegularPoints());
        }

        private readonly IFees   _fees;
        private readonly IPoints _points;
        public PriceCode PriceCode { get; }

        private Price(PriceCode priceCode, IFees fees, IPoints points)
        {
            _fees     = fees;
            _points   = points;
            PriceCode = priceCode;
        }

        public Amount ComputeAmount(Duration duration)
        {
            return _fees.ComputeAmount(duration);
        }

        public int ComputePoints(Duration duration)
        {
            return _points.ComputePoints(duration);
        }
    }
}
