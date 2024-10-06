using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewCompanents.AdminLayout
{
    public class _AdminLayoutSpinnerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
