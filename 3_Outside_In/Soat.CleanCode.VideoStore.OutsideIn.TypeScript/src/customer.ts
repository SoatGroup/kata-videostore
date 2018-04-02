import { Amount } from './amount';
import { Pricer } from './pricer';
import { Rental } from './rental';

export class Customer {
    private _rentals: Rental[] = [];

    constructor(
        readonly name: string,
        readonly computePrice: Pricer) {}

    addRental(rental: Rental) {
        this._rentals.push(rental);
    }

    computeTotals() {
        const details = this.computeDetails();
        return {
            details,
            totalAmount         : details.reduce((sum, x) => sum.add(x.amount), new Amount(0)),
            frequentRenterPoints: details.reduce((sum, x) => sum + x.points, 0),
        };
    }

    private computeDetails() {
        return this._rentals.map(rental => {
            const price = this.computePrice(rental.movie);
            return {
                amount: price.computeAmount(rental.daysRented),
                points: price.computePoints(rental.daysRented),
                title : rental.movie.title
            };
        });
    }
}