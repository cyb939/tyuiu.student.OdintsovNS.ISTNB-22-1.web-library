using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.DataModels;

namespace tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.Controllers
{
    public class BookShelvesController : Controller
    {
        private readonly MyDBContext _context;

        public BookShelvesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: BookShelves
        public async Task<IActionResult> Index()
        {
              return _context.BookSelfs != null ? 
                          View(await _context.BookSelfs.ToListAsync()) :
                          Problem("Entity set 'MyDBContext.BookSelfs'  is null.");
        }

        // GET: BookShelves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookSelfs == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookSelfs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookShelf == null)
            {
                return NotFound();
            }

            return View(bookShelf);
        }

        // GET: BookShelves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookShelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number")] BookShelf bookShelf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookShelf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookShelf);
        }

        // GET: BookShelves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookSelfs == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookSelfs.FindAsync(id);
            if (bookShelf == null)
            {
                return NotFound();
            }
            return View(bookShelf);
        }

        // POST: BookShelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number")] BookShelf bookShelf)
        {
            if (id != bookShelf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookShelf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookShelfExists(bookShelf.Id))
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
            return View(bookShelf);
        }

        // GET: BookShelves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookSelfs == null)
            {
                return NotFound();
            }

            var bookShelf = await _context.BookSelfs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookShelf == null)
            {
                return NotFound();
            }

            return View(bookShelf);
        }

        // POST: BookShelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookSelfs == null)
            {
                return Problem("Entity set 'MyDBContext.BookSelfs'  is null.");
            }
            var bookShelf = await _context.BookSelfs.FindAsync(id);
            if (bookShelf != null)
            {
                _context.BookSelfs.Remove(bookShelf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookShelfExists(int id)
        {
          return (_context.BookSelfs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
