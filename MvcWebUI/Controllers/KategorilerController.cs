using AppCore.Business.Models.Results;
using Business.Model.Services.Bases;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategorilerController(IKategoriService kategoriService)
        {
            this._kategoriService = kategoriService;
        }

        public IActionResult Index()
        {
            List<KategoriModel> model = _kategoriService.Query().ToList();
            return View(model);
        }

        public IActionResult OlusturGetir()
        {
            return View("OlusturHtml");

        }

        public IActionResult OlusturGonder(string Adi,string Aciklamasi)
        {
            KategoriModel model = new KategoriModel()
            {
                Adi = Adi,
                Aciklamasi = Aciklamasi
            };
            var result = _kategoriService.Add(model);
            if (result.IsSuccessful)
                return RedirectToAction(nameof(Index));
               
            return View("Hata",result.Message);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)

                return View("Hata","id gereklidir.");
           KategoriModel model=_kategoriService.Query().SingleOrDefault(k=>k.Id==id);

            if (model == null)
                return View("Hata","Kategori bulunamadı");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KategoriModel model)
        {
            if (ModelState.IsValid)
            {
              var result= _kategoriService.Update(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("",result.Message);
            }
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return View("Hata","id gereklidir.");
            KategoriModel model = _kategoriService.Query().SingleOrDefault(k=>k.Id==id.Value);
            if (model == null)
                return View("Hata","Kategori Bulunamadı");
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
                return View("Hata", "id gereklidir.");
          Result result=  _kategoriService.Delete(id.Value);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));




        }
    }
}
