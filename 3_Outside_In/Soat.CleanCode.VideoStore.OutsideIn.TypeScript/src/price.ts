import { Amount }  from './amount';
import { fees }    from './fees/fee-builder';
import * as Points from './points';

export enum PriceCode {
    Children,
    NewRelease,
    Regular
}

export class Price {
    static createChildren() {
        return new Price(
            PriceCode.Children,
            fees().firstFlat(1.5)
                  .during(3)
                  .thenLinear(1.5),
            Points.regular);
    }

    static createNewRelease() {
        return new Price(
            PriceCode.NewRelease,
            fees().linear(3),
            Points.withBonus);
    }

    static createRegular() {
        return new Price(
            PriceCode.Regular,
            fees().firstFlat(2)
                  .during(2)
                  .thenLinear(1.5),
            Points.regular);
    }

    private constructor(
        readonly code: PriceCode,
        readonly computeAmount: (daysRented: number) => Amount,
        readonly computePoints: (daysRented: number) => number,
    ) { }
}
