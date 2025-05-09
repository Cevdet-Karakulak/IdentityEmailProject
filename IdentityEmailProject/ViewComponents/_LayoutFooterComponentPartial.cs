using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailProject.ViewComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}