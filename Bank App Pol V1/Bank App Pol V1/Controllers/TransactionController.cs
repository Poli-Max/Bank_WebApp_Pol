using Microsoft.AspNetCore.Mvc;
using Bank_App_Pol_V1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bank_App_Pol_V1.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationContext db;

        public TransactionController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(ModTrans model)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == model.User.ID);
            var recipient = db.Users.FirstOrDefault(u => u.ID == model.User2.ID);

            if (user == null || recipient == null)
            {
                return View("UserNotFound");
            }
            if (user.Balance < model.Dop.Amount)
            {
                return View();
            }
            else
            {
                user.Balance -= model.Dop.Amount;
                recipient.Balance += model.Dop.Amount;
                db.SaveChanges();
            }

            // Обновляем модель пользователя с актуальным балансом
            model.User = user;

            return View("CardSuccess", model.User);
        }
    }
}

