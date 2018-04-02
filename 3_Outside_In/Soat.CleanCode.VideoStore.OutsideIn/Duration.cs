using System;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public struct Duration : IEquatable<Duration>
    {
        public int Days { get; }

        public Duration(int days)
        {
            Days = days;
        }

        public Duration Remove(Duration other)
        {
            return new Duration(Days - other.Days);
        }

        // -- ValueObject Members ----------

        public bool Equals(Duration other)
        {
            return Days == other.Days;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Duration && Equals((Duration) obj);
        }

        public override int GetHashCode()
        {
            return Days;
        }

        public static bool operator ==(Duration left, Duration right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Duration left, Duration right)
        {
            return !left.Equals(right);
        }

        public static explicit operator Duration(int days)
        {
            return new Duration(days);
        }

        public static implicit operator int(Duration duration)
        {
            return duration.Days;
        }
    }
}
