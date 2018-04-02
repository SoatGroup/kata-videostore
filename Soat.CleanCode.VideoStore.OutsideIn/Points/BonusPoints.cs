namespace Soat.CleanCode.VideoStore.OutsideIn.Points
{
    public class BonusPoints : IPoints
    {
        public int ComputePoints(Duration duration) => duration.Days > 1 ? 2 : 1;
    }
}
