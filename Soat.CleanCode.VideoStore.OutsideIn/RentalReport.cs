using System.Collections.Generic;
using System.Linq;
using static System.FormattableString;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public class RentalReport
    {
        public readonly string _customer;
        private readonly IPricer _pricer;
        private readonly List<IRental> _rentals = new List<IRental>();

        public Amount AmountOwed { get; private set; }
        public int FrequentRenterPoints { get; private set; }

        public RentalReport(string customer, IPricer pricer)
        {
            _customer = customer;
            _pricer   = pricer;
        }

        public void AddRental(IRental rental)
        {
            _rentals.Add(rental);
        }

        public string Generate()
        {
            return Header() +
                   Details() +
                   Totals();
        }

        private string Details()
        {
            var totals = _rentals
                .Select(rental =>
                {
                    var price = _pricer.GetPrice(rental.Movie);
                    return new
                    {
                        Amount = price.ComputeAmount(rental.Duration),
                        Points = price.ComputePoints(rental.Duration),
                        Movie  = rental.Movie.Title
                    };
                })
                .Aggregate(
                    new
                    {
                        Amount = (Amount) 0m,
                        Points = 0,
                        Details = ""
                    },
                    (current, detail) => new
                    {
                        Amount  = current.Amount.Add(detail.Amount),
                        Points  = current.Points + detail.Points,
                        Details = Invariant($"{current.Details}\t{detail.Movie}\t{detail.Amount.Value:N1}\n")
                    });

            AmountOwed           = totals.Amount;
            FrequentRenterPoints = totals.Points;

            return totals.Details;
        }

        private string Totals()
        {
            return Invariant($"You owed {AmountOwed.Value:N1}\n") +
                   Invariant($"You earned {FrequentRenterPoints} frequent renter points\n");
        }

        private string Header()
        {
            return $"Rental Record for {_customer}\n";
        }
    }
}
