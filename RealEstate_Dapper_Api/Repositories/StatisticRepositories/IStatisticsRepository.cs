namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        //productan gelecek
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AverageProductByRent();
        decimal AverageProductBySail();
        // en çok hangi şehirden var
        string CityNameByMaxProductCount();
        // kaç farklı şehir var
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int AverageRoomCount();

        int ActiveEmployeeCount();

        
    }
}
