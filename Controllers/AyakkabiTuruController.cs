using AyakkabiTur.Models;
using AyakkabiTur.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AyakkabiTur.Controllers
{
    public class AyakkabiTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;

            public AyakkabiTuruController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<AyakkabiTuru> objAyakkabiTuruList = _uygulamaDbContext.AyakkabiTurleri.ToList();
            return View(objAyakkabiTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(AyakkabiTuru ayakkabiTuru)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.AyakkabiTurleri.Add(ayakkabiTuru);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index", "AyakkabiTuru");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AyakkabiTuru? ayakkabiTuruVt = _uygulamaDbContext.AyakkabiTurleri.Find(id);
            if(ayakkabiTuruVt==null) 
            {
                return NotFound();
            }
                return View(ayakkabiTuruVt);
            
        }
        [HttpPost]
        public IActionResult Guncelle(AyakkabiTuru ayakkabiTuru)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.AyakkabiTurleri.Update(ayakkabiTuru);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index", "AyakkabiTuru");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            AyakkabiTuru? ayakkabiTuruVt = _uygulamaDbContext.AyakkabiTurleri.Find(id);
            if (ayakkabiTuruVt == null)
            {
                return NotFound();
            }
            return View(ayakkabiTuruVt);

        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            AyakkabiTuru? ayakkabiTuru = _uygulamaDbContext.AyakkabiTurleri.Find(id);
            if(ayakkabiTuru==null)
            {
                return NotFound();
            }
            _uygulamaDbContext.AyakkabiTurleri.Remove(ayakkabiTuru);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index", "AyakkabiTuru");
        }

    }
}
