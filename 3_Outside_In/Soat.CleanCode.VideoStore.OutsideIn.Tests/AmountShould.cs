using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests
{
    public class AmountShould
    {
        private Amount _sut;

        [Fact]
        public void Prevent_Negative_Value()
        {
            Action act = () => _sut = new Amount(-1);
            act.Should()
               .Throw<ArgumentOutOfRangeException>();
        }

        [Theory, MemberData(nameof(Values))]
        public void Accept_Positive_Value(decimal value)
        {
            _sut = new Amount(value);
            _sut.Value.Should()
                .Be(value);
        }

        [Theory, MemberData(nameof(Values))]
        public void Be_Created_With_An_Explicit_Cast_From_Decimal(decimal value)
        {
            _sut = (Amount) value;
            _sut.Value.Should()
                .Be(value);
        }

        [Theory, MemberData(nameof(Values))]
        public void Be_Implicitly_Casted_To_A_Decimal(decimal value)
        {
            decimal result = new Amount(value);
            result.Should()
                  .Be(value);
        }

        [Theory, MemberData(nameof(Values))]
        public void Be_Equatable(decimal value)
        {
            _sut = new Amount(value);
            var other = new Amount(value);
            _sut.Should()
                .Be(other);
        }

        [Theory, MemberData(nameof(Values))]
        public void Accept_Adding_Decimal(decimal value)
        {
            _sut = new Amount(1);

            var result = _sut.Add(value);
            result.Value.Should()
                  .Be(1 + value);
        }

        [Theory, MemberData(nameof(Values))]
        public void Accept_Adding_Another_Amount(decimal value)
        {
            _sut = new Amount(value);

            var result = _sut.Add((Amount) value);

            result.Value.Should()
                  .Be(2 * value);
        }

        // ReSharper disable once MemberCanBePrivate.Global // public for xUnit
        public static IEnumerable<object[]> Values => new[] { 0, 1, 10 }.Select(value => new object[] { value });
    }
}
