using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Entities.Inventories.It;
using PersistenceLibrary;
using ApplicationLibrary.Repository;

namespace Presentation.WebUI.Controllers
{
    public class SoftwaresController : Helpers.BaseController<Software>
    {
        private readonly IRepositoryBase<Software> _repository;

        public SoftwaresController(IRepositoryBase<Software> repository) : base(repository)
        {
            _repository = repository;
        }
        //// GET: Softwares
        //public async Task<IActionResult> Index()
        //{
        //    var drukarniaDbContext = _context.Softwares.Include(s => s.Device);
        //    return View(await drukarniaDbContext.ToListAsync());
        //}

        //// GET: Softwares/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var software = await _context.Softwares
        //        .Include(s => s.Device)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (software == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(software);
        //}

        //// GET: Softwares/Create
        //public IActionResult Create()
        //{
        //    ViewData["DeviceId"] = new SelectList(_context.DeviceInfos, "Id", "Id");
        //    return View();
        //}

        //// POST: Softwares/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("NameOfProgramm,LicenseInfo,DeviceId,Id")] Software software)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(software);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DeviceId"] = new SelectList(_context.DeviceInfos, "Id", "Id", software.DeviceId);
        //    return View(software);
        //}

        //// GET: Softwares/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var software = await _context.Softwares.FindAsync(id);
        //    if (software == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DeviceId"] = new SelectList(_context.DeviceInfos, "Id", "Id", software.DeviceId);
        //    return View(software);
        //}

        //// POST: Softwares/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("NameOfProgramm,LicenseInfo,DeviceId,Id")] Software software)
        //{
        //    if (id != software.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(software);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SoftwareExists(software.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DeviceId"] = new SelectList(_context.DeviceInfos, "Id", "Id", software.DeviceId);
        //    return View(software);
        //}

        //// GET: Softwares/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var software = await _context.Softwares
        //        .Include(s => s.Device)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (software == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(software);
        //}

        //// POST: Softwares/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var software = await _context.Softwares.FindAsync(id);
        //    _context.Softwares.Remove(software);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SoftwareExists(int id)
        //{
        //    return _context.Softwares.Any(e => e.Id == id);
        //}
    }
}
