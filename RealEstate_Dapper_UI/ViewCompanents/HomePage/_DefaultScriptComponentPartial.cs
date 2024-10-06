using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewCompanents.HomePage
{
    public class _DefaultScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
