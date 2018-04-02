import { Amount }   from './amount';
import { Customer } from './customer';

export function generateReport(customer: Customer) {
    const totals = customer.computeTotals();
    return formatHeader(customer)
        + formatDetails(totals.details)
        + formatTotals(totals.totalAmount, totals.frequentRenterPoints);
}

function formatHeader(customer: Customer) {
    return 'Rental Record for ' + customer.name + '\n';
}

function formatDetails(details: { amount: Amount; title: string }[]) {
    return details.map(x => `\t${x.title}\t${x.amount.valueOf().toFixed(1)}`)
                  .join('\n') + '\n';
}

function formatTotals(totalAmount: Amount, frequentRenterPoints: number) {
    return `You owed ${totalAmount.valueOf().toFixed(1)}\n`
        + `You earned ${frequentRenterPoints} frequent renter points \n`;
}