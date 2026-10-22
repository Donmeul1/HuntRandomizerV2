using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HuntRandomizer.Data;
using HuntRandomizer.Models;
using HuntRandomizer.ViewModels.Weapons;

namespace HuntRandomizer.Controllers
{
    public class WeaponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponsController(ApplicationDbContext db) 
        {
            this._context = db;       
        }


        public async Task<IActionResult> Index()
        {
            List<Weapon> Weapons = _context.Weapons.ToList<Weapon>();
            return View(new WeaponIndexViewModel(Weapons));
        }
    }
}