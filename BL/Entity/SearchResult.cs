using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Entity
{
    public class SearchResult
    {
        public SearchResult(IEnumerable<char> nextChars, IEnumerable<string> railwayStations)
        {
            NextChars = nextChars ?? new char[0];
            RailwayStations = railwayStations ?? new string[0];
        }

        public IEnumerable<char> NextChars { get; private set; }

        public IEnumerable<string> RailwayStations { get; private set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            if (this == obj)
                return true;
            
            var other = (SearchResult)obj;

            return NextChars.SequenceEqual(other.NextChars) && RailwayStations.SequenceEqual(other.RailwayStations);
        }

        public override int GetHashCode()
        {
            return NextChars.GetHashCode() ^ RailwayStations.GetHashCode();
        }
    }
}
