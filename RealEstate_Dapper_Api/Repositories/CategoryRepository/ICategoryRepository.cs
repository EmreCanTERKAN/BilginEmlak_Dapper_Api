using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto CategoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto CategoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
