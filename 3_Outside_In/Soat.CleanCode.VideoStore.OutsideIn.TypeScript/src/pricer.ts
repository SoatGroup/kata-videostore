import { Category, Movie } from './movie';
import { Price }           from './price';

export function computePrice(movie: Movie) {
    if (movie.isNewRelease) {
        return Price.createNewRelease();
    }

    switch (movie.category) {
        case Category.Children:
            return Price.createChildren();

        case Category.Regular:
            return Price.createRegular();

        default:
            throw new RangeError(`movie.category (${movie.category}) is not a valid Category`);
    }
}

export type Pricer = typeof computePrice;
