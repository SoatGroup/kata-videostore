import { Amount } from '../amount';

const flat     = (charge: number) => () => new Amount(charge),
      linear   = (chargePerDay: number) =>
          (days: number) => new Amount(Math.max(0, chargePerDay * days)),
      compound = (flatDuration: number, flatCharge: number, chargePerDayAfter: number) =>
          (days: number) => flat(flatCharge)()
                                .add(linear(chargePerDayAfter)(days - flatDuration));

export { compound, flat, linear };
