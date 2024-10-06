using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetPopularLocationAsync();
        
    }
}
