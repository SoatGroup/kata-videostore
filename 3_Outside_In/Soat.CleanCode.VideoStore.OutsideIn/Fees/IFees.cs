namespace Soat.CleanCode.VideoStore.OutsideIn.Fees
{
    public interface IFees
    {
        Amount ComputeAmount(Duration duration);
    }
}
