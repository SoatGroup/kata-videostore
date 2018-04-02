import { fees }               from './fee-builder';
import { CompoundFeeFixture } from './fixtures/compound-fee-fixture';
import { FlatFeeFixture }     from './fixtures/flat-fee-fixture';
import { LinearFeeFixture }   from './fixtures/linear-fee-fixture';

describe('FeeBuilder', () => {
    describe('Flat', () => {
        const charge     = 5,
              computeFee = fees().flat(charge),
              fixture    = new FlatFeeFixture(charge, computeFee);
        fixture.describe();
    });

    describe('Linear', () => {
        const chargePerDay = 1.5,
              computeFee   = fees().linear(chargePerDay),
              fixture      = new LinearFeeFixture(chargePerDay, computeFee);
        fixture.describe();
    });

    describe('Compound', () => {
        const flatCharge        = 1,
              flatDuration      = 2,
              chargePerDayAfter = 3;

        const computeFee = fees().firstFlat(flatCharge)
                                 .during(flatDuration)
                                 .thenLinear(chargePerDayAfter);

        const fixture = new CompoundFeeFixture(flatCharge, flatDuration, chargePerDayAfter, computeFee);
        fixture.describe();
    });
});
