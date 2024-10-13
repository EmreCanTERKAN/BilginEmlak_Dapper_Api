namespace RealEstate_Dapper_UI.Models
{
    public class JwtResponseModel
    {
        //tokenin kendisini tutar
        public string Token { get; set; }
        //kullanım zamanını tututar
        public DateTime ExpireDate { get; set; }
    }
}
