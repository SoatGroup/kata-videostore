using System;
using FluentAssertions;
using Xbehave;

using static Soat.CleanCode.VideoStore.OutsideIn.Tests.Dsl.Bdd;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests
{
    public class VideoStoreAcceptanceTests
    {
        private readonly Movie _newRelease1 = new Movie("New Release 1", MovieCategory.Children, ReleaseType.New);
        private readonly Movie _newRelease2 = new Movie("New Release 2", MovieCategory.Regular,  ReleaseType.New);
        private readonly Movie _childrens1  = new Movie("Childrens 1",   MovieCategory.Children, ReleaseType.None);
        private readonly Movie _childrens2  = new Movie("Childrens 2",   MovieCategory.Children, ReleaseType.None);
        private readonly Movie _regular1    = new Movie("Regular 1",     MovieCategory.Regular,  ReleaseType.None);
        private readonly Movie _regular2    = new Movie("Regular 2",     MovieCategory.Regular,  ReleaseType.None);
        private readonly Movie _regular3    = new Movie("Regular 3",     MovieCategory.Regular,  ReleaseType.None);

        private readonly RentalReport _report = new RentalReport("CustomerLambda", new Pricer());

        private string _result;

        [Scenario]
        public void Totals_For_One_Regular()
        {
            Given("a regular movie rental of 4 days", AddRental(_regular1, 4))
            .When("the rental report is generated  ", () => _report.Generate())
            .Then("the amount owed is 5.0          ", () => _report.AmountOwed.Value.Should().Be(2m + 2*1.5m))
            .And_("the frequent renter points are 2", () => _report.FrequentRenterPoints.Should().Be(1));
        }

        [Scenario]
        public void Totals_For_Two_Childrens()
        {
            Given("a childrens movie rental of 1 day ", AddRental(_childrens1, 1))
            .And_("a childrens movie rental of 4 days", AddRental(_childrens2, 4))
            .When("the rental report is generated    ", () => _report.Generate())
            .Then("the amount owed is 4.5            ", () => _report.AmountOwed.Value.Should().Be(3*1.5m))
            .And_("the frequent renter points are 2  ", () => _report.FrequentRenterPoints.Should().Be(2));
        }

        [Scenario]
        public void Totals_For_Two_New_Release()
        {
            Given("a new release movie rental of 1 day ", AddRental(_newRelease1, 1))
            .And_("a new release movie rental of 4 days", AddRental(_newRelease2, 4))
            .When("the rental report is generated      ", () => _report.Generate())
            .Then("the amount owed is 15.0             ", () => _report.AmountOwed.Value.Should().Be(5*3m))
            .And_("the frequent renter points are 3    ", () => _report.FrequentRenterPoints.Should().Be(3));
        }

        [Scenario]
        public void Report_For_Three_Regulars()
        {
            const string expected =
                "Rental Record for CustomerLambda\n"
                + "\tRegular 1\t2.0\n"
                + "\tRegular 2\t2.0\n"
                + "\tRegular 3\t3.5\n" + "You owed 7.5\n"
                + "You earned 3 frequent renter points\n";

            Given("a regular movie rental of 1 day   ", AddRental(_regular1, 1))
            .And_("a regular movie rental of 2 days  ", AddRental(_regular2, 2))
            .And_("a regular movie rental of 3 days  ", AddRental(_regular3, 3))
            .When("the rental report is generated    ", () => _result = _report.Generate())
            .Then("it should be formatted as expected", () => _result.Should().Be(expected));
        }

        private Action AddRental(Movie movie, int days)
        {
            return () => _report.AddRental(new Rental(movie, new Duration(days)));
        }
    }
}
