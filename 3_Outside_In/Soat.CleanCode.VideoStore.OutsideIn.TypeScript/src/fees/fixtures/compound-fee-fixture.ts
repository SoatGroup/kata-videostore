import { Amount } from '../../amount';

export class CompoundFeeFixture {
    constructor(
        readonly flatCharge: number,
        readonly flatDuration: number,
        readonly chargePerDayAfter: number,
        readonly computeFee: (days: number) => Amount,
    ) {}

    describe() {
        this.flatFirst();
        this.linearAfter();
    }

    private flatFirst() {
        this.allDaysFlat
            .forEach(days =>
                it(`should be flat first, given days ${days}`, () => {
                    const result = this.computeFee(days);
                    expect(result.valueOf()).toBe(this.flatCharge);
                }));
    }

    private get allDaysFlat() {
        const flatDuration = this.flatDuration;

        function* generator() {
            for (let days = 0; days <= flatDuration; days++) {
                yield days;
            }
        }

        return Array.from(generator());
    }

    private linearAfter() {
        [1, 2, 3].forEach(daysAfter =>
            it(`should be linear after, given daysAfter ${daysAfter}`, () => {
                const result = this.computeFee(this.flatDuration + daysAfter);
                expect(result.valueOf()).toBe(this.flatCharge + daysAfter * this.chargePerDayAfter);
            }));
    }
}