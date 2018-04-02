export class Amount {
    // Use a multiplicative factor to handle an integer value internally
    // To prevent rounding errors with floats
    private readonly factor: number;

    constructor(private readonly value: number, decimals = 2) {
        if (value < 0) {
            throw new RangeError('Negative value not allowed');
        }

        this.factor = Math.pow(10, decimals);
        this.value  = this.factor * value;
    }

    add(other: number | Amount) {
        const otherValue = new Amount(+other).valueOf() * this.factor;
        const sum = (otherValue + this.value) / this.factor;
        return new Amount(sum);
    }

    valueOf() {
        return this.value / this.factor;
    }
}