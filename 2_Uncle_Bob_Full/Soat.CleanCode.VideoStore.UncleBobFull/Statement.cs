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
            Initialize();
            var statementText = Header();
            foreach (var rental in _rentals)
            {
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

                statementText      += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                TotalAmount += thisAmount;
            }

            statementText += "You owed " + TotalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            statementText += "You earned " + FrequentRenterPoints.ToString() + " frequent renter points\n";

            return statementText;
        }

        private string Header()
        {
            return $"Rental Record for {CustomerName}\n";
        }

        private void Initialize()
        {
            FrequentRenterPoints = 0;
            TotalAmount = 0m;
        }
    }
}
