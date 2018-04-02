namespace Soat.CleanCode.VideoStore.OutsideIn.Fees
{
    public class CompoundFees : IFees
    {
        private readonly Duration _flatDuration;
        private readonly Amount   _flatCharge;
        private readonly IFees    _linearFees;

        public CompoundFees(Duration flatDuration, Amount flatCharge, Amount chargePerDayAfter)
        {
            _flatDuration = flatDuration;
            _flatCharge   = flatCharge;
            _linearFees   = new LinearFees(chargePerDayAfter);
        }

        public Amount ComputeAmount(Duration duration) =>
            _linearFees.ComputeAmount(duration.Remove(_flatDuration))
                       .Add(_flatCharge);
    }
}
