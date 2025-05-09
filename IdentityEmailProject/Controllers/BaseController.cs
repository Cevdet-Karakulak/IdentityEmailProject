using IdentityEmailProject.Context;
using IdentityEmailProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class BaseController : Controller
{
    protected readonly EmailContext _context;
    protected readonly UserManager<AppUser> _userManager;

    public BaseController(EmailContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var email = user?.Email;

            if (email != null)
            {
                ViewBag.GelenMesajSayisi = _context.Messages.Count(x => x.ReceiverEmail == email && !x.IsRead);
                ViewBag.GidenMesajSayisi = _context.Messages.Count(x => x.SenderEmail == email);
                ViewBag.UserFullName = user.Name + " " + user.Surname;
            }
        }

        base.OnActionExecuting(context);
    }
}
