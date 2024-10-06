using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category(CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            // dinamik parametre tanımlandı..
            var parameters = new DynamicParameters();
            parameters.Add("categoryName", categoryDto.CategoryName);
            parameters.Add("categoryStatus", true);
            using (var connecttion = _context.CreateConnection())
            {
                // işlemleri veri tabanına yazdırıyor
                await connecttion.ExecuteAsync(query, parameters);
            }
        }
        public async void DeleteCategory(int id)
        {
            

            var parameters = new DynamicParameters();
            parameters.Add("categoryID", id);

            using (var connection = _context.CreateConnection())
            {
                // Önce o kategoriye bağlı ürünleri sil
                string deleteProductsQuery = "DELETE FROM Product WHERE ProductCategory = @categoryID";
                await connection.ExecuteAsync(deleteProductsQuery, parameters);

                // Sonra kategoriyi sil
                string deleteCategoryQuery = "DELETE FROM Category WHERE CategoryId = @categoryID";
                await connection.ExecuteAsync(deleteCategoryQuery, parameters);
            }

        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection  = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category where CategoryID=@CategoryID";
            var parameters= new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
               var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        

    }
}
