﻿using System.Security.Claims;

namespace RealEstate_Dapper_UI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        //sub değeri id olacak idye göre ilgili değeri döndürecek.
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
