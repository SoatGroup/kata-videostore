import { Customer }       from './customer';
import { Movie }          from './movie';
import { movies }         from './movie-factory';
import { computePrice }   from './pricer';
import { Rental }         from './rental';
import { generateReport } from './report';

describe('generateReport', () => {
    let customer: Customer;

    beforeEach(() => {
        customer = new Customer('Abc', computePrice);
    });

    it('should return the listing for multiple mixed statement', () => {
        addRental(movies.children(), 3);
        addRental(movies.regular(1), 2);
        addRental(movies.regular(2), 1);
        addRental(movies.newReleaseChildren(1), 1);
        addRental(movies.newReleaseRegular(2), 1);

        expect(generateReport(customer))
            .toBe(`Rental Record for Abc
\tChildren\t1.5
\tRegular1\t2.0
\tRegular2\t2.0
\tNewRelease1\t3.0
\tNewRelease2\t3.0
You owed 11.5
You earned 5 frequent renter points 
`);
    });

    function addRental(movie: Movie, daysRented: number) {
        customer.addRental(new Rental(movie, daysRented));
    }
});
