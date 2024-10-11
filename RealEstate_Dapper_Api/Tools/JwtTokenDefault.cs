namespace RealEstate_Dapper_Api.Tools
{
    // TOKENIMIZ BAŞLANGIÇTA SABİT DEFAULT AYARLARI OLACAK ONLARI TUTULDUĞU CLASS
    public class JwtTokenDefault
    {
        public const string ValidAudience = "https://localhost";
        //Kim tararfından yayınlanacağı belirtilir
        public const string ValidIssuer = "https://localhost";
        // Anahtarı
        public const string Key = "BilginEmlak..010101010101Asp.NetCore";
        // Geçerli olacak zamanı .
        public const int Expire = 5;
    }
}
