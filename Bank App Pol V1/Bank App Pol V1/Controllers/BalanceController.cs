using Microsoft.AspNetCore.Mvc;
using Bank_App_Pol_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_App_Pol_V1.Controllers
{
    public class BalanceController : Controller
    {
        private readonly ApplicationContext db;
        public BalanceController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(User_Bank model)
        {
            var user = db.Users.FirstOrDefault(u => u.ID == model.ID);

            if (user != null)
            {
                // Обновляем модель пользователя с актуальным балансом
                model.Balance = user.Balance;


                return View("CardSuccess", model);
            }
            else
            {
                return View();
            }
        }
    }
}

