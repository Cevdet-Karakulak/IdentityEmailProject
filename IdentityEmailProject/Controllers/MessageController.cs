using IdentityEmailProject.Context;
using IdentityEmailProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityEmailProject.Controllers
{
    public class MessageController : BaseController
    {
        public MessageController(EmailContext context, UserManager<AppUser> userManager)
            : base(context, userManager)
        {

        }

        [Authorize]
        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user?.Email;

            var gelenMesajlar = _context.Messages
                .Where(x => x.ReceiverEmail == email)
                .ToList();

            return View(gelenMesajlar);
        }

        public async Task<IActionResult> SendBox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string emailValue = values.Email;

            var sendMessageList = _context.Messages
                .Where(x => x.SenderEmail == emailValue)
                .ToList();

            return View(sendMessageList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string senderMail = values.Email;

            message.SenderEmail = senderMail;
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["MessageSent"] = "true";

            return RedirectToAction("SendBox");
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (message != null && !message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return View(message);
        }

        [Authorize]
        public async Task<IActionResult> Search(string query, string page)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user.Email;

            var results = _context.Messages
                .Where(m => (m.ReceiverEmail == email || m.SenderEmail == email) &&
                            (m.Subject.Contains(query) || m.MessageDetail.Contains(query)))
                .ToList();

            if (page == "inbox")
            {
                return View("Inbox", results);
            }
            else if (page == "sendbox")
            {
                return View("SendBox", results);
            }
            else
            {
                return RedirectToAction("Inbox");
            }
        }
    }
}
