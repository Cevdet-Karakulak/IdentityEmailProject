using IdentityEmailProject.Context;
using IdentityEmailProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailProject.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly EmailContext _emailContext;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(EmailContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {
            _emailContext = context;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> ProfileDetail()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ProfilePicture = values.ProfileImageUrl;
            ViewBag.Name = values.Name;
            ViewBag.Surname = values.Surname;
            ViewBag.Email = values.Email;
            ViewBag.Username = values.UserName;
            ViewBag.Phone = values.PhoneNumber;
           

            return View();
        }
    }
}
