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
    public class DeviceInfoesController : Helpers.BaseController<DeviceInfo>
    {
        private readonly IRepositoryBase<DeviceInfo> _repository;

        public DeviceInfoesController(IRepositoryBase<DeviceInfo> repository) : base(repository)
        {
            _repository = repository;
        }
        //private readonly DrukarniaDbContext _context;

        //public DeviceInfoesController(DrukarniaDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: DeviceInfoes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.DeviceInfos.ToListAsync());
        //}

        //// GET: DeviceInfoes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var deviceInfo = await _context.DeviceInfos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (deviceInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(deviceInfo);
        //}

        //// GET: DeviceInfoes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: DeviceInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("DateOfPurchase,Owner,Id")] DeviceInfo deviceInfo)
        {
            return await base.Create(deviceInfo);
        }

        //// GET: DeviceInfoes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var deviceInfo = await _context.DeviceInfos.FindAsync(id);
        //    if (deviceInfo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(deviceInfo);
        //}

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("DateOfPurchase,Owner,Id")] DeviceInfo deviceInfo)
        {
            return await base.Edit(id, deviceInfo);
        }
        //// POST: DeviceInfoes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public override async Task<IActionResult> Edit(int id, [Bind("DateOfPurchase,Owner,Id")] DeviceInfo deviceInfo)
        //{
        //    if (id != deviceInfo.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //_context.Update(deviceInfo);
        //            //await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DeviceInfoExists(deviceInfo.Id))
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
        //    return View(deviceInfo);
        //}

        //// GET: DeviceInfoes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var deviceInfo = await _context.DeviceInfos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (deviceInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(deviceInfo);
        //}

        //// POST: DeviceInfoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var deviceInfo = await _context.DeviceInfos.FindAsync(id);
        //    _context.DeviceInfos.Remove(deviceInfo);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DeviceInfoExists(int id)
        //{
        //    return _context.DeviceInfos.Any(e => e.Id == id);
        //}
    }
}
