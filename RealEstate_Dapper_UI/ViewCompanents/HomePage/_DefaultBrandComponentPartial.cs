using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewCompanents.HomePage
{
    public class _DefaultBrandComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke () { return View(); }
    }
}
