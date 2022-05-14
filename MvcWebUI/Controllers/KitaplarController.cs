using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Model.Services.Bases;
using Business.Models;

namespace MvcWebUI.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KitapContext _context;

        private readonly IKitapServise _kitapService;
        private readonly IKategoriService _kategoriService;

        public KitaplarController(IKitapServise kitapService,IKategoriService kategoriService)
        {
            _kitapService = kitapService;
            _kategoriService = kategoriService;
        }

        // GET: Kitaplar
        //public async Task<IActionResult> Index()
        //{
        //    var kitapContext = _context.Kitaplar.Include(k => k.Kategori);
        //    return View(await kitapContext.ToListAsync());
        //}
        public IActionResult Index()
        {
         
            var model = _kitapService.Query().ToList();
            return View(model);
        }

        // GET: Kitaplar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: Kitaplar/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_kategoriService.Query().ToList(), "Id", "Adi");
            KitapModel model = new KitapModel()
            {
                 StokMiktari=0,
                 //YazarAdiSoyadi=""

            };
            return View(model);
        }

        // POST: Kitaplar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Adi,YazarAdiSoyadi,Aciklamasi,StokMiktari,KategoriId,Id,Guid")] Kitap kitap)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(kitap);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Adi", kitap.KategoriId);
        //    return View(kitap);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KitapModel kitap)
        {
            if (ModelState.IsValid)
            {
                var result = _kitapService.Add(kitap);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewData["KategoriId"] = new SelectList(_kategoriService.Query().ToList(), "Id", "Adi", kitap.KategoriId);
            return View(kitap);
        }

        // GET: Kitaplar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Adi", kitap.KategoriId);
            return View(kitap);
        }

        // POST: Kitaplar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adi,YazarAdiSoyadi,Aciklamasi,StokMiktari,KategoriId,Id,Guid")] Kitap kitap)
        {
            if (id != kitap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Adi", kitap.KategoriId);
            return View(kitap);
        }

        // GET: Kitaplar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kitaplar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitaplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kitaplar == null)
            {
                return Problem("Entity set 'KitapContext.Kitaplar'  is null.");
            }
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
          return (_context.Kitaplar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
