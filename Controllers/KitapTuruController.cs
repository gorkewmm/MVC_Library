using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje.Models;
using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository kitapTuruRepository)
        {
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruListesi = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruListesi);
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
                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.Kaydet();
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
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(x => x.Id == id);
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
                _kitapTuruRepository.Guncelle(kitapTuru);
                _kitapTuruRepository.Kaydet();
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
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(x => x.Id == id);
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
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(x => x.Id == id);

            if (kitapTuru == null)
            {
                return NotFound();
            }

            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "KitapTuru");
        }
    }
}
