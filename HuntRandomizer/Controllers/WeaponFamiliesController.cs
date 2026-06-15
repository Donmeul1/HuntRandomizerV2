using HuntRandomizer.Data;
using Microsoft.AspNetCore.Mvc;
using HuntRandomizer.Models;
using Microsoft.EntityFrameworkCore;
using HuntRandomizer.ViewModels.WeaponFamilies;

namespace HuntRandomizer.Controllers
{
    public class WeaponFamiliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponFamiliesController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var weaponFamilies = await _context.WeaponFamilies.OrderBy(wf => wf.Name).ToListAsync();

            var viewModel = new ListWeaponFamiliesViewModel(weaponFamilies);

            return View(viewModel);
        }
    }
}