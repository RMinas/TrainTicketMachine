using System.Collections.Generic;
using BL.Collection;

namespace BL.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly TrieCol trie;

        public StationRepository(IEnumerable<string> stations)
        {
            trie = new TrieCol(stations);
        }

        public IEnumerable<string> GetAllThatStartWith(string name)
        {
            return trie.Find(name);
        }
    }
}
