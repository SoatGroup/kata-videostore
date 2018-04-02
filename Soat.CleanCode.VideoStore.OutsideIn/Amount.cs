using System;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public struct Amount : IEquatable<Amount>
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Negative value not allowed");
            Value = value;
        }

        public Amount Add(decimal value)
        {
            return new Amount(value + this);
        }

        // -- ValueObject Members ----------

        public bool Equals(Amount other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (obj is Amount amount && Equals(amount));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Amount left, Amount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Amount left, Amount right)
        {
            return !Equals(left, right);
        }

        public static explicit operator Amount(decimal value)
        {
            return new Amount(value);
        }

        public static implicit operator decimal(Amount amount)
        {
            return amount.Value;
        }
    }
}
