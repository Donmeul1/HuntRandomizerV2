using HuntRandomizer.Data;
using Microsoft.AspNetCore.Mvc;
using HuntRandomizer.Models;
using Microsoft.EntityFrameworkCore;
using HuntRandomizer.ViewModels.WeaponFamilies;
using Microsoft.AspNetCore.Authorization;

namespace HuntRandomizer.Controllers
{
    public class WeaponFamiliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponFamiliesController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var weaponFamilies = await _context.WeaponFamilies.OrderBy(wf => wf.Name).ToListAsync();

            var viewModel = new ListWeaponFamiliesViewModel(weaponFamilies);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWeaponFamilyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Name = model.Name.Trim();
            model.Description = model.Description.Trim();

            if (await WeaponFamilyExists(model.Name)) {
                ModelState.AddModelError(nameof(model.Name), "A weapon family with this name already exists.");
                return View(model);
            }

            WeaponFamily family = new WeaponFamily(model.Name, model.Description);
            _context.WeaponFamilies.Add(family);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WeaponFamilyExists(string name)
        {
            return await _context.WeaponFamilies.AnyAsync(p => p.Name == name);
        }
    }
}