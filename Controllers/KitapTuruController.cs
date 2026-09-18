using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje.Models;
using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _context;

        public KitapTuruController(UygulamaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _context.KitapTurleri.ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _context.KitapTurleri.Add(kitapTuru);
                _context.SaveChanges();
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "KitapTuru");
            }

            return View();
        }
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuru = _context.KitapTurleri.Find(id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            return View(kitapTuru);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _context.KitapTurleri.Update(kitapTuru);
                _context.SaveChanges();
                TempData["basarili"] = "Kitap Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "KitapTuru");
            }
            return View();
        }


        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuru = _context.KitapTurleri.Find(id);
            if(kitapTuru == null)
            {
                return NotFound();
            }

            return View(kitapTuru);
        }

        [HttpPost]
        [ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuru = _context.KitapTurleri.Find(id);

            if (kitapTuru == null)
            {
                return NotFound();
            }

            _context.KitapTurleri.Remove(kitapTuru);
            _context.SaveChanges();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "KitapTuru");
        }
    }
}
