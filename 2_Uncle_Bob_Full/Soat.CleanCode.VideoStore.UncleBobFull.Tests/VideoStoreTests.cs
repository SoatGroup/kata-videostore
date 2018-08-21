using Xunit;

namespace Soat.CleanCode.VideoStore.UncleBobFull.Tests
{
    public class VideoStoreTests
    {
        private readonly Statement _statement = new Statement("Customer");

        private readonly Movie _newRelease1 = new Movie("NEW_RELEASE_1", Movie.NEW_RELEASE);
        private readonly Movie _newRelease2 = new Movie("NEW_RELEASE_2", Movie.NEW_RELEASE);
        private readonly Movie _childrens   = new Movie("CHILDREN",      Movie.CHILDREN);
        private readonly Movie _regular1    = new Movie("REGULAR_1",     Movie.REGULAR);
        private readonly Movie _regular2    = new Movie("REGULAR_2",     Movie.REGULAR);
        private readonly Movie _regular3    = new Movie("REGULAR_3",     Movie.REGULAR);

        [Fact]
        public void TestSingleNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.Generate();
            Assert.Equal(9.0m, _statement.TotalAmount);
            Assert.Equal(2,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestDualNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.AddRental(new Rental(_newRelease2, 3));
            _statement.Generate();
            Assert.Equal(18.0m, _statement.TotalAmount);
            Assert.Equal(4,     _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestSingleChildrensStatementTotals()
        {
            _statement.AddRental(new Rental(_childrens, 3));
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
