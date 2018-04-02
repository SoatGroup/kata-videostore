import { Amount } from '../../amount';

export class FlatFeeFixture {
    constructor(
        readonly charge: number,
        readonly computeFee: (days: number) => Amount,
    ) {}

    describe() {
        [0, 1, 10].forEach(days =>
            it(`should be always flat, given days ${days}`, () => {
                const result = this.computeFee(days);
                expect(result.valueOf()).toBe(this.charge);
            })
        );
    }
}