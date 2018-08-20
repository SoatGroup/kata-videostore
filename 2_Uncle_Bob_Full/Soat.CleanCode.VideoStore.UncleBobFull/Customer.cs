using System.Collections.Generic;
using System.Globalization;

namespace Soat.CleanCode.VideoStore.UncleBobFull
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; }
        public int FrequentRenterPoints { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            var result = "Rental Record for " + Name + "\n";
            foreach (var each in _rentals)
            {
                var thisAmount = 0m;

                //dtermines the amount for each line
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5m;
                        }
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDREN:
                        thisAmount += 1.5m;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5m;
                        }
                        break;
                }

                FrequentRenterPoints++;

                if (each.Movie.PriceCode == Movie.NEW_RELEASE
                    && each.DaysRented > 1)
                {
                    FrequentRenterPoints++;
                }

                result      += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                TotalAmount += thisAmount;
            }

            result += "You owed " + TotalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + FrequentRenterPoints.ToString() + " frequent renter points \n";

            return result;
        }
    }
}
