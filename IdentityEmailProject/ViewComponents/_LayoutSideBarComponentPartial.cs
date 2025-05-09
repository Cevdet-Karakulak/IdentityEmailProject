using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailProject.ViewComponents
{
    public class _LayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}