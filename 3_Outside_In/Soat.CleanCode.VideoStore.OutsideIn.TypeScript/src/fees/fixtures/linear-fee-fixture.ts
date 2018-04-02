import { Amount } from '../../amount';

export class LinearFeeFixture {
    constructor(
        readonly chargePerDay: number,
        readonly computeFee: (days: number) => Amount,
    ) {}

    describe() {
        [0, 1, 10].forEach(days =>
            it(`should be linear, given days ${days}`, () => {
                const result = this.computeFee(days);
                expect(result.valueOf()).toBe(days * this.chargePerDay);
            })
        );
    }
}