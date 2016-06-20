using BL.Entity;

namespace BL.Service
{
    public interface IService
    {
        SearchResult StartingWith(string name);
    }
}
