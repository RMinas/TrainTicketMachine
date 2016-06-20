using System.Linq;
using BL.Entity;
using BL.Repository;

namespace BL.Service
{
    public class Service : IService
    {
        private readonly IStationRepository stationRepository;

        public Service(IStationRepository stationRepository)
        {
            this.stationRepository = stationRepository;
        }

        public SearchResult StartingWith(string statName)
        {
            var railwayStations = stationRepository.GetAllThatStartWith(statName);

            var nextPossibleChars = railwayStations.Where(station => station.Length > statName.Length).Select(station => station[statName.Length]);

            return new SearchResult(nextPossibleChars, railwayStations);
        }
    }
}
