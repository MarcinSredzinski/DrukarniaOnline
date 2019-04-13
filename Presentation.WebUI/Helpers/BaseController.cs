using ApplicationLibrary.Repository;
using CoreLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Presentation.WebUI.Helpers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        private IReposotoryBase<T> _repository;

        public BaseController(IReposotoryBase<T> repository)
        {
            _repository = repository;
        }

        // GET: ControllerName
        public virtual async Task<IActionResult> Index()
        {
            return View(await _repository.FindAllAsync());
        }

        // GET: ControllerName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _repository.GetDetailsAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);

        }

        // GET: ControllerName/Create
        public virtual IActionResult Create()
        {
            return View();
        }

        // POST: ControllerName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create([Bind("Name,Id")] T entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(entity);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: ControllerName/Edit/5
        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _repository.GetDetailsAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        // POST: ControllerName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] T entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(entity);
                    await _repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repository.GetDetailsAsync(entity.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: ControllerName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await _repository.GetDetailsAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // POST: ControllerName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _repository.Delete(await _repository.GetDetailsAsync(id));
            await _repository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

