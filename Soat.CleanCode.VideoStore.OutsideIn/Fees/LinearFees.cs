using System;

namespace Soat.CleanCode.VideoStore.OutsideIn.Fees
{
    public class LinearFees : IFees
    {
        private readonly Amount _chargePerDay;

        public LinearFees(Amount chargePerDay)
        {
            _chargePerDay = chargePerDay;
        }

        public Amount ComputeAmount(Duration duration) =>
            new Amount(Math.Max(0, _chargePerDay.Value * duration.Days));
    }
}
