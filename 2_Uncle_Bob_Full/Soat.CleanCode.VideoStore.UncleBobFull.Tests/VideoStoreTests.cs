using Xunit;

namespace Soat.CleanCode.VideoStore.UncleBobFull.Tests
{
    public class VideoStoreTests
    {
        private readonly Statement _statement;

        public VideoStoreTests()
        {
            _statement = new Statement("Fred");
        }

        [Fact]
        public void TestSingleNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(new Movie("The cell", Movie.NEW_RELEASE), 3));
            _statement.Generate();
            Assert.Equal(9.0m, _statement.TotalAmount);
            Assert.Equal(2,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestDualNewReleaseStatementTotals()
        {
            _statement.AddRental(new Rental(new Movie("The cell",         Movie.NEW_RELEASE), 3));
            _statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.NEW_RELEASE), 3));
            _statement.Generate();
            Assert.Equal(18.0m, _statement.TotalAmount);
            Assert.Equal(4,     _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestSingleChildrensStatementTotals()
        {
            _statement.AddRental(new Rental(new Movie("The Tigger Movie", Movie.CHILDREN), 3));
            _statement.Generate();
            Assert.Equal(1.5m, _statement.TotalAmount);
            Assert.Equal(1,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestMultipleRegularStatementTotals()
        {
            _statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            _statement.AddRental(new Rental(new Movie("8 1/2",                   Movie.REGULAR), 2));
            _statement.AddRental(new Rental(new Movie("Eraserhead",              Movie.REGULAR), 3));
            _statement.Generate();
            Assert.Equal(7.5m, _statement.TotalAmount);
            Assert.Equal(3,    _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestMultipleRegularStatementFormat()
        {
            _statement.AddRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            _statement.AddRental(new Rental(new Movie("8 1/2",                   Movie.REGULAR), 2));
            _statement.AddRental(new Rental(new Movie("Eraserhead",              Movie.REGULAR), 3));

            Assert.Equal(@"Rental Record for Fred
	Plan 9 from Outer Space	2.0
	8 1/2	2.0
	Eraserhead	3.5
You owed 7.5
You earned 3 frequent renter points
", _statement.Generate());
        }
    }
}
