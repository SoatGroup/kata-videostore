import { Customer }     from './customer';
import { Movie }        from './movie';
import { movies }       from './movie-factory';
import { computePrice } from './pricer';
import { Rental }       from './rental';

describe('Customer', () => {
    let customer: Customer;

    beforeEach(() => {
        customer = new Customer('Abc', computePrice);
    });

    describe('computeTotals', () => {
        it('should handle single NewRelease statement', () => {
            addRental(movies.newReleaseChildren(), 3);

            const result = customer.computeTotals();
            expect(result.totalAmount.valueOf()).toBe(9);
            expect(result.frequentRenterPoints).toBe(2);
        });

        it('should handle dual NewRelease statement', () => {
            addRental(movies.newReleaseRegular(1), 3);
            addRental(movies.newReleaseRegular(2), 3);

            const result = customer.computeTotals();
            expect(result.totalAmount.valueOf()).toBe(18);
            expect(result.frequentRenterPoints).toBe(4);
        });

        it('should handle single children statement', () => {
            addRental(movies.children(), 3);

            const result = customer.computeTotals();
            expect(result.totalAmount.valueOf()).toBe(1.5);
            expect(result.frequentRenterPoints).toBe(1);
        });

        it('should handle long rental with a single children statement', () => {
            addRental(movies.children(), 4);

            const result = customer.computeTotals();
            expect(result.totalAmount.valueOf()).toBe(3);
            expect(result.frequentRenterPoints).toBe(1);
        });

        it('should handle multiple regular statement', () => {
            addRental(movies.regular(1), 1);
            addRental(movies.regular(2), 2);
            addRental(movies.regular(3), 3);

            const result = customer.computeTotals();
            expect(result.totalAmount.valueOf()).toBe(7.5);
            expect(result.frequentRenterPoints).toBe(3);
        });

        function addRental(movie: Movie, daysRented: number) {
            customer.addRental(new Rental(movie, daysRented));
        }
    });
});

