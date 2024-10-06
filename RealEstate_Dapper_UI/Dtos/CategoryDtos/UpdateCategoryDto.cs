namespace RealEstate_Dapper_UI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        // SQLDE bit olarak tutulan değer c#da bool olarak tutulur.
        public bool CategoryStatus { get; set; }
    }
}
