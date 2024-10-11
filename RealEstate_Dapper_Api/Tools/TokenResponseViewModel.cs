namespace RealEstate_Dapper_Api.Tools
{
    public class TokenResponseViewModel
    {
        //Sağ tık diyerek bir constructor oluşturuyoruz
        //Uygulama ayağı kalktığı zaman token ve expireDate örneklerini bizim için alıyor..
        public TokenResponseViewModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        // Tokenin yanıtı
        public string Token { get; set; }
        // Tokenin ömrünü belirten property
        public DateTime ExpireDate { get; set; }
        
    }
}
