import * as Fees from './fees';

export function fees() {
    return builder;
}

const builder = {
    firstFlat(charge: number) {
        return new During(charge);
    },
    flat(charge: number) {
        return Fees.flat(charge);
    },
    linear(chargePerDay: number) {
        return Fees.linear(chargePerDay);
    }
};

class During {
    constructor(readonly flatCharge = 0) {}

    during(flatDuration: number) {
        return new Linear(this.flatCharge, flatDuration);
    }
}

class Linear {
    constructor(
        readonly flatCharge   = 0,
        readonly flatDuration = 0,
    ) {}

    thenLinear(chargePerDayAfter: number) {
        return Fees.compound(this.flatDuration, this.flatCharge, chargePerDayAfter);
    }
}