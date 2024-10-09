using Dapper;
using Microsoft.IdentityModel.Tokens;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
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

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            // dinamik parametre tanımlandı..
            var parameters = new DynamicParameters();
            parameters.Add("cityName", createPopularLocationDto.CityName);
            parameters.Add("imageUrl", createPopularLocationDto.ImageUrl);
            using (var connecttion = _context.CreateConnection())
            {
                // işlemleri veri tabanına yazdırıyor
                await connecttion.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationID=@locationID";

            var parameters = new DynamicParameters();
            parameters.Add("locationID", id);


            using (var connecttion = _context.CreateConnection())
            {
                await connecttion.ExecuteAsync(query, parameters);
            };
        }

        public async Task<GetPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation Where LocationID=@locationID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetPopularLocationDto>(query, parameters);
                return values;

            }
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

        public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityName, ImageUrl=@imageUrl where LocationID=@locationID";
            var parameters = new DynamicParameters();

            parameters.Add("@locationID", updatePopularLocationDto.LocationID);
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
