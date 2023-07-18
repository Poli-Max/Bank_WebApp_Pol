using Microsoft.AspNetCore.Mvc;
using Bank_App_Pol_V1.Models;

namespace Bank_App_Pol_V1.Controllers
{
    public class WithdrawalsController : Controller
    {
        private readonly ApplicationContext db;

        public WithdrawalsController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(Mod model)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == model.User.ID);

            if (user == null)
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
                db.SaveChanges();
            }

            // Обновляем модель пользователя с актуальным балансом
            model.User = user;

            return View("CardSuccess", model.User);
        }

    }
}

