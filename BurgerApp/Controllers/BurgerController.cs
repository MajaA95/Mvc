using Microsoft.AspNetCore.Mvc;
using BurgerApp.Models;

namespace BurgerApp.Controllers
{
    public class BurgerController:Controller
    {
        public IActionResult GetAllBurgers ()
        {
            List<Burger> burgersDb = StaticDb.Burgers;

            
            return View(burgersDb);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");


            }

            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);

            if (burger == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(burger);
        }
    }

}
