using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests.AutoMoq
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() :
            base(() => new Fixture().Customize(new AutoMoqCustomization())) { }
    }
}
