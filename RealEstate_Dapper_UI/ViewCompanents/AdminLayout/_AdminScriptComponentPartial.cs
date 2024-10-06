using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewCompanents.AdminLayout
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
