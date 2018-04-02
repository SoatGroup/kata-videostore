namespace Soat.CleanCode.VideoStore.OutsideIn.Fees
{
    public class FeesBuilder
    {
        public WithDuring FirstFlat(decimal charge)
        {
            return new WithDuring(charge);
        }

        public IFees Linear(decimal chargePerDay)
        {
            return new LinearFees(
                new Amount(chargePerDay));
        }

        public class WithDuring
        {
            private readonly decimal _flatCharge;

            public WithDuring(decimal flatCharge)
            {
                _flatCharge = flatCharge;
            }

            public WithLinear During(int flatDuration)
            {
                return new WithLinear(_flatCharge, flatDuration);
            }
        }

        public class WithLinear
        {
            private readonly decimal _flatCharge;
            private readonly int _flatDuration;

            internal WithLinear(decimal flatCharge = 0, int flatDuration = 0)
            {
                _flatCharge   = flatCharge;
                _flatDuration = flatDuration;
            }

            public IFees ThenLinear(decimal chargePerDayAfter)
            {
                return new CompoundFees(
                    new Duration(_flatDuration),
                    new Amount(_flatCharge),
                    new Amount(chargePerDayAfter));
            }
        }
    }
}
