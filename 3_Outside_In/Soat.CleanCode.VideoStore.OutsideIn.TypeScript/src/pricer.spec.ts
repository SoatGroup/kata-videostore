import { movies }       from './movie-factory';
import { PriceCode }    from './price';
import { computePrice } from './pricer';

describe('Pricer', () => {
    it('should return a children price given a children movie from last year', () => {
        const movie = movies.children();
        const result = computePrice(movie);
        expect(result.code).toBe(PriceCode.Children);
    });

    it('should return a regular price given a regular movie from last year', () => {
        const movie = movies.regular();
        const result = computePrice(movie);
        expect(result.code).toBe(PriceCode.Regular);
    });

    it('should return a new release price given a regular movie from last week', () => {
        const movie = movies.newReleaseRegular();
        const result = computePrice(movie);
        expect(result.code).toBe(PriceCode.NewRelease);
    });

    it('should return a new release price given a children movie from last week', () => {
        const movie = movies.newReleaseChildren();
        const result = computePrice(movie);
        expect(result.code).toBe(PriceCode.NewRelease);
    });

    it('should throw an error given an unknown category movie', () => {
        const movie = movies.unknown();
        expect(() => computePrice(movie))
            .toThrow(RangeError);
    });
});