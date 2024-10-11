namespace RealEstate_Dapper_Api.Tools
{
    public class GetChecktAppUserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        // IsExist Bu kullanıcı bu rolu içeriyor tanımlamasını yapmak için kullandığımız property
        public bool IsExist { get; set; }
    }
}
