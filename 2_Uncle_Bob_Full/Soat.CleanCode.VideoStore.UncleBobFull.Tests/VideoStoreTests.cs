using Xunit;

namespace Soat.CleanCode.VideoStore.UncleBobFull.Tests
{
    public class VideoStoreTests
    {
        private readonly Statement _statement = new Statement("Customer");

        private readonly Movie _newRelease1 = new NewReleaseMovie("NEW_RELEASE_1");
        private readonly Movie _newRelease2 = new NewReleaseMovie("NEW_RELEASE_2");
        private readonly Movie _children    = new ChildrenMovie("CHILDREN");
        private readonly Movie _regular1    = new RegularMovie("REGULAR_1");
        private readonly Movie _regular2    = new RegularMovie("REGULAR_2");
        private readonly Movie _regular3    = new RegularMovie("REGULAR_3");

        [Fact]
        public void TestSingleNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.Generate();
            Assert.Equal(9m, _statement.TotalAmount);
            Assert.Equal(2,  _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestDualNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.AddRental(new Rental(_newRelease2, 3));
            _statement.Generate();
            Assert.Equal(18m, _statement.TotalAmount);
            Assert.Equal(4,   _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestSingleChildrenStatementTotals()
        {
            _statement.AddRental(new Rental(_children, 3));
            _statement.Generate();
            Assert.Equal(1.5m, _statement.TotalAmount);
            Assert.Equal(1,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestMultipleRegularStatementTotals()
        {
            _statement.AddRental(new Rental(_regular1, 1));
            _statement.AddRental(new Rental(_regular2, 2));
            _statement.AddRental(new Rental(_regular3, 3));
            _statement.Generate();
            Assert.Equal(7.5m, _statement.TotalAmount);
            Assert.Equal(3,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestMultipleRegularStatementFormat()
        {
            _statement.AddRental(new Rental(_regular1, 1));
            _statement.AddRental(new Rental(_regular2, 2));
            _statement.AddRental(new Rental(_regular3, 3));

            Assert.Equal(@"Rental Record for Customer
	REGULAR_1	2.0
	REGULAR_2	2.0
	REGULAR_3	3.5
You owed 7.5
You earned 3 frequent renter points
", _statement.Generate());
        }
    }
}
