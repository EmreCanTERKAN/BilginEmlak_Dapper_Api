namespace RealEstate_Dapper_Api.Dtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        // SQLDE bit olarak tutulan değer c#da bool olarak tutulur.
        public bool CategoryStatus { get; set; }
    }
}
