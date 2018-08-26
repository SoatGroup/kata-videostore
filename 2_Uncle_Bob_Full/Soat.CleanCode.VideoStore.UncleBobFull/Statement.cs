using System;
using System.Collections.Generic;
using System.Linq;

namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Statement
    {
        private readonly List<Rental> rentals = new List<Rental>();

        private string CustomerName { get; }
        public int FrequentRenterPoints { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Statement(string customerName)
        {
            CustomerName = customerName;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string Generate()
        {
            ClearTotals();

            return Header() +
                   RentalLines() +
                   Footer();
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
            var rentalLines = rentals.Select(RentalLine);
            return string.Join(string.Empty, rentalLines);
        }

        private string RentalLine(Rental rental)
        {
            var rentalAmount = rental.DetermineAmount();
            var rentalPoints = rental.DetermineFrequentRenterPoints();

            FrequentRenterPoints += rentalPoints;
            TotalAmount          += rentalAmount;

            return FormatRentalLine(rental, rentalAmount);
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
