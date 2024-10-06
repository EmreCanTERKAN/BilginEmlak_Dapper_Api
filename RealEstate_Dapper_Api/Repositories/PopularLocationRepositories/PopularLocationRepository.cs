using Dapper;
using Microsoft.IdentityModel.Tokens;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection() )
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();

            }
            
           
        }
    }
}
