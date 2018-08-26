using System;
using System.Collections.Generic;
using System.Globalization;

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
            var rentalLines = "";
            foreach (var rental in _rentals)
                rentalLines += RentalLine(rental);

            return rentalLines;
        }

        private string RentalLine(Rental rental)
        {
            var rentalLine = "";
            var thisAmount = 0m;

            //dtermines the amount for each line
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                    {
                        thisAmount += (rental.DaysRented - 2) * 1.5m;
                    }

                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5m;
                    if (rental.DaysRented > 3)
                    {
                        thisAmount += (rental.DaysRented - 3) * 1.5m;
                    }

                    break;
            }

            FrequentRenterPoints++;

            if (rental.Movie.PriceCode == Movie.NEW_RELEASE
                && rental.DaysRented > 1)
            {
                FrequentRenterPoints++;
            }

            rentalLine += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + Environment.NewLine;
            TotalAmount += thisAmount;
            return rentalLine;
        }

        private string Footer()
        {
            var totalAmount = TotalAmount.ToString("0.0", CultureInfo.InvariantCulture);
            return $"You owed {totalAmount}{Environment.NewLine}" +
                   $"You earned {FrequentRenterPoints} frequent renter points{Environment.NewLine}";
        }
    }
}
