import { Amount } from './amount';

describe('Amount', () => {
    let sut: Amount;

    it('should prevent negative value', () => {
        expect(() => sut = new Amount(-1))
            .toThrow(RangeError);
    });

    [0, 1, 10].forEach(value => {
        it(`should accept positive value ${value}`, () => {
            sut = new Amount(value);
            expect(sut.valueOf()).toBe(value);
        });

        it(`should be implicitly casted to a number given value ${value}`, () => {
            sut = new Amount(value);
            expect(+sut).toEqual(value);
        });

        it(`should be equatable given value ${value}`, () => {
            sut = new Amount(value);
            const other = new Amount(value);
            expect(sut).not.toBe(other);
            expect(sut).toEqual(other);
        });
    });

    describe('add', () => {
        const value1   = 0.1,
              value2   = 0.2,
              expected = 0.3;

        it('should have 0.1 + 0.2 != 0.3 with plain number', () => {
            expect(value1 + value2).not.toBe(expected);
        });

        it('should support financial computation adding a number', () => {
            sut = new Amount(value1);
            const result = sut.add(value2);
            expect(result.valueOf()).toBe(expected);
        });

        it('should support financial computation adding another amount', () => {
            sut = new Amount(value1);
            const result = sut.add(new Amount(value2));
            expect(result.valueOf()).toBe(expected);
        });
    });
});