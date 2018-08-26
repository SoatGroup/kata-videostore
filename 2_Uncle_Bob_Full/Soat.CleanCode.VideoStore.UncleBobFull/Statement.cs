using System;
using System.Collections.Generic;
using System.Linq;

namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Statement
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        private string CustomerName { get; }
        public int FrequentRenterPoints { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Statement(string customerName)
        {
            CustomerName = customerName;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Generate()
        {
            ClearTotals();
            var statementText = Header();
            statementText += RentalLines();
            statementText += Footer();
            return statementText;
        }

        private void ClearTotals()
        {
            FrequentRenterPoints = 0;
            TotalAmount = 0m;
        }

        private string Header()
        {
            return $"Rental Record for {CustomerName}{Environment.NewLine}";
        }

        private string RentalLines()
        {
            var rentalLines = _rentals.Select(RentalLine);
            return string.Join(string.Empty, rentalLines);
        }

        private string RentalLine(Rental rental)
        {
            var rentalAmount = DetermineAmount(rental);
            var rentalPoints = DetermineFrequentRenterPoints(rental);

            FrequentRenterPoints += rentalPoints;
            TotalAmount          += rentalAmount;

            return FormatRentalLine(rental, rentalAmount);
        }

        private static decimal DetermineAmount(Rental rental)
        {
            var rentalAmount = 0m;
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    rentalAmount += 2;
                    if (rental.DaysRented > 2)
                    {
                        rentalAmount += (rental.DaysRented - 2) * 1.5m;
                    }

                    break;
                case Movie.NEW_RELEASE:
                    rentalAmount += rental.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    rentalAmount += 1.5m;
                    if (rental.DaysRented > 3)
                    {
                        rentalAmount += (rental.DaysRented - 3) * 1.5m;
                    }

                    break;
            }

            return rentalAmount;
        }

        private static int DetermineFrequentRenterPoints(Rental rental)
        {
            var bonusIsEarned = rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1;
            if (bonusIsEarned)
                return 2;
            return 1;
        }

        private static string FormatRentalLine(Rental rental, decimal rentalAmount) =>
            FormatLine($"\t{rental.Title}\t{rentalAmount:0.0}");

        private string Footer() =>
            FormatLine($"You owed {TotalAmount:0.0}") +
            FormatLine($"You earned {FrequentRenterPoints} frequent renter points");

        private static string FormatLine(FormattableString source) =>
            FormattableString.Invariant(source) + Environment.NewLine;
    }
}
