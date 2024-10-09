﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();

            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Adress,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();

            }
        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "update Product Set DealOfTheDay=0 where ProductID=@productId";
            // dinamik parametre tanımlandı..
            var parameters = new DynamicParameters();
            parameters.Add("productId", id);

            using (var connecttion = _context.CreateConnection())
            {
                // işlemleri veri tabanına yazdırıyor
                await connecttion.ExecuteAsync(query, parameters);
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "update Product Set DealOfTheDay=1 where ProductID=@productId";
            // dinamik parametre tanımlandı..
            var parameters = new DynamicParameters();
            parameters.Add("productId", id);

            using (var connecttion = _context.CreateConnection())
            {
                // işlemleri veri tabanına yazdırıyor
                await connecttion.ExecuteAsync(query, parameters);
            }
        }
    }
}
