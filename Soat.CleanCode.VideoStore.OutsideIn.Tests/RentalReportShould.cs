using System;
using System.Collections.Generic;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Soat.CleanCode.VideoStore.OutsideIn.Tests.AutoMoq;
using Xunit;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests
{
    public class RentalReportShould
    {
//        [Theory, AutoMoqData]
//        public void Generate_Header(string customer, [Frozen] Mock<IPricer> pricer)
//        {
//            var sut    = new RentalReport(customer, pricer.Object);
//            var result = sut.Generate();
//            result.Should()
//                  .StartWith($"Rental Record for {customer}");
//        }
//
//        [Theory, AutoMoqData]
//        public void Generate_Totals(string customer, [Frozen] Mock<IPricer> pricer)
//        {
//            var sut    = new RentalReport(customer, pricer.Object);
//            var result = sut.Generate();
//            result.Should()
//                  .EndWith("You owed 0.0\n" + "You earned 0 frequent renter points");
//        }
//
//        [Theory, AutoMoqData]
//        public void Report_No_Points_Given_No_Rentals(string customer, [Frozen] Mock<IPricer> pricer)
//        {
//            var sut = new RentalReport(customer, pricer.Object);
//            sut.Generate();
//            sut.FrequentRenterPoints.Should()
//               .Be(0);
//        }
//
//        [Theory, AutoMoqData]
//        public void Report_No_Amount_Given_No_Rentals(string customer, [Frozen] Mock<IPricer> pricer)
//        {
//            var sut = new RentalReport(customer, pricer.Object);
//            sut.Generate();
//            sut.AmountOwed.Value.Should()
//               .Be(0);
//        }
//
//        [Theory, AutoMoqData]
//        public void Report_Total_Amount_Of_Added_Rentals(string customer,
//                                                         [Frozen] Mock<IPricer> pricer,
//                                                         decimal[] amounts)
//        {
//            var sut      = new RentalReport(customer, pricer.Object);
//            var expected = AddRentals(sut, amounts, (a, b) => a + b, (rental, amount) => (Amount) Math.Abs(amount));
//
//            sut.Generate();
//            sut.AmountOwed.Value.Should()
//               .Be(expected);
//        }
//
//        [Theory, AutoMoqData]
//        public void Report_Total_Points_Of_Added_Rentals(string customer,
//                                                         [Frozen] Mock<IPricer> pricer,
//                                                         int[] severalPoints)
//        {
//            var sut      = new RentalReport(customer, pricer.Object);
//            var expected = AddRentals(sut, severalPoints, (a, b) => a + b, (rental, points) => points);
//
//            sut.Generate();
//            sut.FrequentRenterPoints.Should()
//               .Be(expected);
//        }
//
//        [Theory, AutoMoqData]
//        public void Report_Added_Rentals_Movie_Details(string customer, [Frozen] Mock<IPricer> pricer, string[] movies)
//        {
//            var sut = new RentalReport(customer, pricer.Object);
//            AddRentals(sut, movies, (a, b) => "",
//                       (rental, movie) => rental.Movie = new Movie(movie, MovieCategory.Regular, ReleaseType.None));
//
//            var result = sut.Generate();
//
//            result.Should()
//                  .ContainAll(movies);
//        }
//
//        private static T AddRentals<T>(RentalReport sut,
//                                       IEnumerable<T> values,
//                                       Func<T, T, T> combineValues,
//                                       Action<FakeRental, T> setValue)
//        {
//            var totals = default(T);
//            foreach (var value in values)
//            {
//                totals = combineValues(totals, value);
//
//                var rental = new FakeRental();
//                setValue(rental, value);
//                sut.AddRental(rental);
//            }
//
//            return totals;
//        }
//
//        [Theory, AutoMoqData]
//        public void Use_Pricer(string customer, [Frozen] Mock<IPricer> pricer, RentalReport sut)
//        {
//            // TODO
//        }
    }
}
