using System;

namespace Soat.CleanCode.VideoStore.OutsideIn
{
    public struct Movie : IEquatable<Movie>
    {
        public string Title { get; }
        public MovieCategory Category { get; }
        public ReleaseType ReleaseType { get; }

        public Movie(string title, MovieCategory category, ReleaseType releaseType)
        {
            Title       = title;
            Category    = category;
            ReleaseType = releaseType;
        }

        // -- ValueObject Members ----------

        public bool Equals(Movie other)
        {
            return string.Equals(Title, other.Title) && Category == other.Category && ReleaseType == other.ReleaseType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Movie movie && Equals(movie);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Title != null
                                    ? Title.GetHashCode()
                                    : 0);
                hashCode = (hashCode * 397) ^ (int) Category;
                hashCode = (hashCode * 397) ^ (int) ReleaseType;
                return hashCode;
            }
        }

        public static bool operator ==(Movie left, Movie right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Movie left, Movie right)
        {
            return !left.Equals(right);
        }
    }
}
