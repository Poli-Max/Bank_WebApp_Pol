using Microsoft.AspNetCore.Mvc;
using Bank_App_Pol_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_App_Pol_V1.Controllers
{
    public class ReplenishmentController : Controller
    {
        private readonly ApplicationContext db;

        public ReplenishmentController(ApplicationContext context)
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

            if (user != null)
            {
                user.Balance += model.Dop.Amount;

                // Обновляем модель пользователя с актуальным балансом
                model.User = user;
            }
            else
            {
                User_Bank newUser = new User_Bank
                {
                    ID = model.User.ID,
                    Name = "Новый пользователь",
                    Balance = model.Dop.Amount
                };

                db.Users.Add(newUser);

                // Обновляем модель пользователя с актуальным балансом
                model.User = newUser;
            }

            db.SaveChanges();

            return View("CardSuccess", model.User);
        }
    }
}
