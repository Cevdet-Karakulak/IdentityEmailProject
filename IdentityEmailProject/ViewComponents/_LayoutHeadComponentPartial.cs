using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailProject.ViewComponents
{
    public class _LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}