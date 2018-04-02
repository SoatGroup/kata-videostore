import { Price } from './price';

describe('Price', () => {
    let sut: Price;

    describe('ChildrenPrice', () => {
        beforeEach(() => {
            sut = Price.createChildren();
        });

        describe('computeAmount()', () => {
            describe('first fixed', () => {
                checkComputeAmount(0, 1.5);
                checkComputeAmount(1, 1.5);
                checkComputeAmount(2, 1.5);
                checkComputeAmount(3, 1.5);
            });

            describe('then linear', () => {
                checkComputeAmount(4, 3);
                checkComputeAmount(5, 4.5);
            });
        });

        describe('computePoints()', () => {
            [0, 1, 2, 3].forEach(daysRented => {
                it(`should return 1 given ${daysRented} day(s) rented`, () => {
                    const result = sut.computePoints(daysRented);
                    expect(result).toBe(1);
                });
            });
        });
    });

    describe('NewReleasePrice', () => {
        beforeEach(() => {
            sut = Price.createNewRelease();
        });

        describe('computeAmount()', () => {
            describe('always linear', () => {
                checkComputeAmount(0, 0);
                checkComputeAmount(1, 3);
                checkComputeAmount(2, 6);
                checkComputeAmount(3, 9);
            });
        });

        describe('computePoints()', () => {
            [0, 1].forEach(daysRented => {
                it(`should return 1 given ${daysRented} day(s) rented`, () => {
                    const result = sut.computePoints(daysRented);
                    expect(result).toBe(1);
                });
            });

            [2, 3].forEach(daysRented => {
                it(`should return 2 given ${daysRented} day(s) rented`, () => {
                    const result = sut.computePoints(daysRented);
                    expect(result).toBe(2);
                });
            });
        });
    });

    describe('RegularPrice', () => {
        beforeEach(() => {
            sut = Price.createRegular();
        });

        describe('computeAmount()', () => {
            describe('first fixed', () => {
                checkComputeAmount(0, 2);
                checkComputeAmount(1, 2);
                checkComputeAmount(2, 2);
            });

            describe('then linear', () => {
                checkComputeAmount(3, 3.5);
                checkComputeAmount(4, 5);
            });
        });

        describe('computePoints()', () => {
            [0, 1, 2, 3].forEach(daysRented => {
                it(`should return 1 given ${daysRented} day(s) rented`, () => {
                    const result = sut.computePoints(daysRented);
                    expect(result).toBe(1);
                });
            });
        });
    });

    function checkComputeAmount(daysRented: number, expected: number) {
        it(`should return ${expected} given ${daysRented} day(s) rented`, () => {
            const result = sut.computeAmount(daysRented);
            expect(result.valueOf()).toBe(expected);
        });
    }
});