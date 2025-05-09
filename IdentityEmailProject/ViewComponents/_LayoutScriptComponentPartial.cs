using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailProject.ViewComponents
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}