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
        private readonly ILogger<WeaponFamiliesController> _logger;

        public WeaponFamiliesController(ApplicationDbContext context, ILogger<WeaponFamiliesController> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? responseCode)
        {
            var weaponFamilies = await _context.WeaponFamilies.OrderBy(wf => wf.Id).ToListAsync();

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

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int? responseCode = null)
        {
            if (responseCode != null)
            {
                switch (responseCode)
                {
                    case (int)ResponseCode.DeleteRestricted:
                        ModelState.AddModelError("", "The currently selected weapon family still has weapons associated with it, and can't be deleted unless you explicitly check the " +
                        "delete all associated weapons checkbox.");
                        break;
                    case (int)ResponseCode.DeleteTransactionFailed:
                        ModelState.AddModelError("", "The delete operation did not succeed. Please try again.");
                        break;
                }
            }

            var familyToDelete = await _context.WeaponFamilies.FindAsync(id);

            if (familyToDelete == null)
            {
                return NotFound();
            }

            var viewModel = new DeleteWeaponFamilyViewModel(familyToDelete, false);

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, bool cascadeDelete)
        {
            if (id <= 0)
                return BadRequest();

            var family = await _context.WeaponFamilies.Include(f => f.WeaponsInFamily).FirstOrDefaultAsync(f => f.Id == id);

            if (family == null)
                return NotFound();

            if(family.WeaponsInFamily.Any() && !cascadeDelete)
                return RedirectToAction(nameof(Delete), new { id, responseCode = (int)ResponseCode.DeleteRestricted });

            try
            {
                if(family.WeaponsInFamily.Any() && cascadeDelete)
                {
                    _context.Weapons.RemoveRange(family.WeaponsInFamily);
                }
                _context.Remove(family);

                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, $"Failed to delete Weapon Family with ID {id}", id);

                return RedirectToAction(nameof(Delete), new { id, responseCode = (int)ResponseCode.DeleteTransactionFailed });
            }


            return RedirectToAction(nameof(Index), new { responseCode = (int)ResponseCode.DeleteSuccess });
        }

        private async Task<bool> WeaponFamilyExists(string name)
        {
            return await _context.WeaponFamilies.AnyAsync(p => p.Name == name);
        }

        private enum ResponseCode
        {
            DeleteSuccess = 1,
            DataNotFound = -2,
            DeleteRestricted = -3,
            DeleteTransactionFailed = -4
        }
    }
}