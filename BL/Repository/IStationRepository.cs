using System.Collections.Generic;

namespace BL.Repository
{
    public interface IStationRepository
    {
        IEnumerable<string> GetAllThatStartWith(string name);
    }
}