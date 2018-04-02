using Xunit;

namespace Soat.CleanCode.VideoStore.UncleBob.Tests
{
    public class VideoStoreTests
    {
        private readonly RentalStatement _statement;
        private readonly Movie _newRelease1;
        private readonly Movie _newRelease2;
        private readonly Movie _childrens;
        private readonly Movie _regular1;
        private readonly Movie _regular2;
        private readonly Movie _regular3;

        public VideoStoreTests()
        {
            _statement   = new RentalStatement("Customer Name");
            _newRelease1 = new NewReleaseMovie("New Release 1");
            _newRelease2 = new NewReleaseMovie("New Release 2");
            _childrens   = new ChildrensMovie("Childrens");
            _regular1    = new RegularMovie("Regular 1");
            _regular2    = new RegularMovie("Regular 2");
            _regular3    = new RegularMovie("Regular 3");
        }

        private void AssertAmountAndPointsForReport(decimal expectedAmount, int expectedPoints) {
            Assert.Equal(expectedAmount, _statement.AmountOwed);
            Assert.Equal(expectedPoints, _statement.FrequentRenterPoints);
        }

        [Fact]
        public void TestSingleNewReleaseStatement()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.MakeRentalStatement();
            AssertAmountAndPointsForReport(9.0m, 2);
        }

        [Fact]
        public void TestDualNewReleaseStatement()
        {
            _statement.AddRental(new Rental(_newRelease1, 3));
            _statement.AddRental(new Rental(_newRelease2, 3));
            _statement.MakeRentalStatement();
            AssertAmountAndPointsForReport(18.0m, 4);
        }

        [Fact]
        public void TestSingleChildrensStatement()
        {
            _statement.AddRental(new Rental(_childrens, 3));
            _statement.MakeRentalStatement();
            AssertAmountAndPointsForReport(1.5m, 1);
        }

        [Fact]
        public void TestMultipleRegularStatement()
        {
            _statement.AddRental(new Rental(_regular1, 1));
            _statement.AddRental(new Rental(_regular2, 2));
            _statement.AddRental(new Rental(_regular3, 3));
            _statement.MakeRentalStatement();
            AssertAmountAndPointsForReport(7.5m, 3);
        }

        [Fact]
        public void TestRentalStatementFormat() {
            _statement.AddRental(new Rental(_regular1, 1));
            _statement.AddRental(new Rental(_regular2, 2));
            _statement.AddRental(new Rental(_regular3, 3));

            Assert.Equal(
                "Rental Record for Customer Name\n" +
                "\tRegular 1\t2.0\n" +
                "\tRegular 2\t2.0\n" +
                "\tRegular 3\t3.5\n" +
                "You owed 7.5\n" +
                "You earned 3 frequent renter points\n",
                _statement.MakeRentalStatement());
        }
    }
}
