using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewCompanents.EstateAgent
{
    public class _EstateAgentLayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
