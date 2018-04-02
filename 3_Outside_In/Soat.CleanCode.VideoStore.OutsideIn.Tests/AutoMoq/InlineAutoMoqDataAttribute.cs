using AutoFixture.Xunit2;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests.AutoMoq
{
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] objects) :
            base(new AutoMoqDataAttribute(), objects) { }
    }
}
