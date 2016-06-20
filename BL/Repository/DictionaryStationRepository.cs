using System.Collections.Generic;
using System.Linq;

namespace BL.Repository
{
    public class DictionaryStationRepository : IStationRepository
    {
        private readonly Dictionary<string, IList<string>> stationsDictionary = new Dictionary<string, IList<string>>();

        public DictionaryStationRepository(IEnumerable<string> stations)
        {
            BeginDict(stations);
        }

        public IEnumerable<string> GetAllThatStartWith(string name)
        {
            IList<string> stations;
            stationsDictionary.TryGetValue(name, out stations);
            return stations ?? new List<string>(0);
        }

        private void BeginDict(IEnumerable<string> stations)
        {
            IEnumerable<string> orderedStations = stations.OrderBy(s => s);

            foreach (var station in orderedStations)
            {
                for (int i = 1; i <= station.Length; i++)
                {
                    var prefix = station.Remove(i, station.Length - i);

                    IList<string> collection;
                    if (!stationsDictionary.TryGetValue(prefix, out collection))
                    {
                        collection = new List<string>();
                        stationsDictionary.Add(prefix, collection);
                    }

                    collection.Add(station);
                }
            }
        }
    }
}
