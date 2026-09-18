using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje.Models;

namespace WebUygulamaProje.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;

        public KitapController(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public IActionResult Index()
        {
            List<Kitap> objKitaplar = _kitapRepository.GetAll().ToList();
            return View(objKitaplar);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Ekle(kitap);
                _kitapRepository.Kaydet();

                return RedirectToAction("Index", "Kitap");
            }

            return View();
        }
        public IActionResult Guncelle(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Kitap kitap = _kitapRepository.Get(x => x.Id == id);
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Guncelle(kitap);
                _kitapRepository.Kaydet();

                return RedirectToAction("Index", "Kitap");
            }

            return View();
            
        }

        public IActionResult Sil(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Kitap kitap = _kitapRepository.Get(x => x.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }

        [HttpPost]
        [ActionName("Sil")]
        public IActionResult SilPost(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Kitap kitap = _kitapRepository.Get(x => x.Id == id);
            if(kitap == null)
            {
                return NotFound();
            }

            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();

            return RedirectToAction("Index", "Kitap");
        }

    }
}
