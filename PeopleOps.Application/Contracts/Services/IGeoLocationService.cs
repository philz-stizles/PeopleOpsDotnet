using PeopleOps.Application.Models;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface IGeoLocationService
    {
        Task<GeoInfoDto> GetGeoInfo();
    }
}
