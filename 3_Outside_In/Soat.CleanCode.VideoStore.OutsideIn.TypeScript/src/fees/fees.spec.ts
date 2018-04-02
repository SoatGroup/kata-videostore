import * as Fees              from './fees';
import { CompoundFeeFixture } from './fixtures/compound-fee-fixture';
import { FlatFeeFixture }     from './fixtures/flat-fee-fixture';
import { LinearFeeFixture }   from './fixtures/linear-fee-fixture';

describe('Fees', () => {
    describe('Flat', () => {
        const charge     = 5,
              computeFee = Fees.flat(charge),
              fixture    = new FlatFeeFixture(charge, computeFee);
        fixture.describe();
    });

    describe('Linear', () => {
        const chargePerDay = 1.5,
              computeFee   = Fees.linear(chargePerDay),
              fixture      = new LinearFeeFixture(chargePerDay, computeFee);
        fixture.describe();
    });

    describe('Compound', () => {
        const flatCharge        = 5,
              flatDuration      = 3,
              chargePerDayAfter = 1.5;

        const computeFee = Fees.compound(flatDuration, flatCharge, chargePerDayAfter);

        const fixture = new CompoundFeeFixture(flatCharge, flatDuration, chargePerDayAfter, computeFee);
        fixture.describe();
    });
});
