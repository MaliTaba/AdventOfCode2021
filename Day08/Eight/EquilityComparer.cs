using System.Diagnostics.CodeAnalysis;

namespace Eight
{
    public static partial class SevenSegmentSearch
    {
        public class EquilityComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y)
            {
                var interceptCount = x.Intersect(y).Count();
                return x.Count() == interceptCount && y.Count() == interceptCount;
            }

            public int GetHashCode([DisallowNull] string obj)
            {
                return obj.Count();
            }
        }
    }
}

