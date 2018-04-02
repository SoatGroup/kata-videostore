namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public interface IPricer
    {
        IPrice GetPrice(Movie movie);
    }
}
