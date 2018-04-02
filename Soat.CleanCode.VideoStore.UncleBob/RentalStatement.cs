using System.Collections.Generic;
using System.Linq;
using static System.FormattableString;

namespace Soat.CleanCode.VideoStore.UncleBob
{
    public class RentalStatement
    {
        private readonly string        _name;
        private readonly IList<Rental> _rentals = new List<Rental>();

        public decimal AmountOwed { get; private set; }
        public int FrequentRenterPoints { get; private set; }

        public RentalStatement(string customerName)
        {
            _name = customerName;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string MakeRentalStatement()
        {
            ClearTotals();
            return MakeHeader() + MakeRentalLines() + MakeSummary();
        }

        private void ClearTotals()
        {
            AmountOwed           = 0;
            FrequentRenterPoints = 0;
        }

        private string MakeHeader() => $"Rental Record for {_name}\n";

        private string MakeRentalLines() => _rentals.Aggregate("", (lines, rental) => lines + MakeRentalLine(rental));

        private string MakeRentalLine(Rental rental)
        {
            var amount = rental.DetermineAmount();

            FrequentRenterPoints += rental.DetermineFrequentRenterPoints();
            AmountOwed           += amount;

            return FormatRentalLine(rental, amount);
        }

        private static string FormatRentalLine(Rental rental, decimal amount) =>
            Invariant($"\t{rental.Title}\t{amount:0.0}\n");

        private string MakeSummary() =>
            Invariant($"You owed {AmountOwed}\nYou earned {FrequentRenterPoints} frequent renter points\n");
    }
}
