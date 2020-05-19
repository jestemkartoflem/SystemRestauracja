using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SystemRestauracja.Data;
using SystemRestauracja.Models;

namespace SystemRestauracja.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class MenuController : Controller
    {
        private RestaurantDbContext _context;
        private readonly UserManager<UserAccount> _userManager;

        public MenuController(RestaurantDbContext context, UserManager<UserAccount> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult OrderMenu()
        {
            ViewData["username"] = User.Identity.Name;
            var model = new OrderMenuViewModel()
            {
                CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(), //potrzebne do menu
                ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(), //potrzebne do menu
                Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(), //potrzebne do menu
                Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier) && (x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie==StatusZamowienie.Dodawane)).ToList(), //wszystkie zamowienia tego uzytkownika, potrzebne do wybrania innego obecnie aktywnego zamowienia
                Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie zestawy pasujace do obecnie wybranego zamowienia
                DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie dania w zestawach tego uzytkownika
                //SelectedZestawId = zestaw.Id, //zestaw do ktorego obecnie wybieramy
                //SelectedZamowienieId = zamowienie.Id, //obecnie wybrane zamowienie
                Symbole = _context.Symbole.ToList(),
                SymboleDoDania = _context.SymboleDoDania.ToList()

            };
            return View(model);
        }

        [HttpGet]
        [Route("Menu/OrderMenu/{selectedZamowienieId}")]
        public IActionResult OrderMenu(Guid selectedZamowienieId)
        {
            ViewData["username"] = User.Identity.Name;
            var model = new OrderMenuViewModel()
            {
                CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(), //potrzebne do menu
                ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(), //potrzebne do menu
                Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(), //potrzebne do menu
                Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == 
                    User.FindFirstValue(ClaimTypes.NameIdentifier) && 
                    (x.StatusZamowienie == StatusZamowienie.Oczekujace || 
                    x.StatusZamowienie == StatusZamowienie.Dodawane)).ToList(), //wszystkie zamowienia tego uzytkownika, potrzebne do wybrania innego obecnie aktywnego zamowienia
                Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie zestawy pasujace do obecnie wybranego zamowienia
                DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie dania w zestawach tego uzytkownika
                //SelectedZestawId = zestaw.Id, //zestaw do ktorego obecnie wybieramy
                SelectedZamowienieId = selectedZamowienieId, //obecnie wybrane zamowienie
                Symbole = _context.Symbole.ToList(),
                SymboleDoDania = _context.SymboleDoDania.ToList()

            };
            return View(model);
        }

        [HttpGet]
        [Route("Menu/OrderMenu/{selectedZamowienieId}/{selectedZestawId}")]
        public IActionResult OrderMenu(Guid selectedZamowienieId, Guid selectedZestawId)
        {
            ViewData["username"] = User.Identity.Name;
            var model = new OrderMenuViewModel()
            {
                CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(), //potrzebne do menu
                ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(), //potrzebne do menu
                Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(), //potrzebne do menu
                Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier) && (x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Dodawane)).ToList(), //wszystkie zamowienia tego uzytkownika, potrzebne do wybrania innego obecnie aktywnego zamowienia
                Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie zestawy pasujace do obecnie wybranego zamowienia
                DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie dania w zestawach tego uzytkownika
                SelectedZestawId = selectedZestawId, //zestaw do ktorego obecnie wybieramy
                SelectedZamowienieId = selectedZamowienieId, //obecnie wybrane zamowienie
                Symbole = _context.Symbole.ToList(),
                SymboleDoDania = _context.SymboleDoDania.ToList()

            };
            return View(model);
        }

        [HttpPost]
        [Route("Menu/AddZamowienie")]
        public IActionResult AddZamowienie()
        {
            var order = new Zamowienie
            {
                StatusZamowienie = StatusZamowienie.Dodawane,
                CenaSuma = 0,
                CreatedBy = "SYSTEM",
                ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            _context.Zamowienia.Add(order);
            _context.SaveChanges();
            order.NormalizedName = order.Id.ToString().Replace("-", "");
            _context.Zamowienia.Update(order);
            _context.SaveChanges();

            return RedirectToAction("OrderMenu", new { selectedZamowienieId = order.Id });
        }

        [HttpPost]
        [Route("/Menu/RemoveZamowienie/{zamowienieId}")]
        public IActionResult RemoveZamowienie(Guid zamowienieId)
        {
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zamowienieId);
            if (zamowienie != null && zamowienie.StatusZamowienie == StatusZamowienie.Dodawane)
            {
                _context.Zamowienia.Remove(_context.Zamowienia.Find(zamowienieId));
                _context.SaveChanges();
            }

            return RedirectToAction("OrderMenu");
        }

        [HttpGet]
        [Route("/Menu/SelectZamowienie/{zamowienieId}")]
        public IActionResult SelectZamowienie(Guid zamowienieId)
        {
            return RedirectToAction("OrderMenu", new { selectedZamowienieId = zamowienieId });
        }

        [HttpGet]
        [Route("/Menu/AddZestaw/{zamowienieId}")]
        public IActionResult AddZestaw(Guid zamowienieId)
        {
            var set = new Zestaw
            {
                ZamowienieId = zamowienieId,
                StatusZestawu = StatusZestaw.Dodawany,
                CenaZestawu = 0,
                CreatedBy = "SYSTEM",
                ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            };
            _context.Zestawy.Add(set);
            _context.SaveChanges();
            set.NormalizedName = set.Id.ToString().Replace("-", "");
            _context.Zestawy.Update(set);
            _context.SaveChanges();

            return RedirectToAction("OrderMenu", new { selectedZamowienieId = zamowienieId, selectedZestawId = set.Id });
        }

        [HttpPost]
        [Route("/Menu/RemoveZestaw/{zestawId}")]
        public IActionResult RemoveZestaw(Guid zestawId)
        {
            var zestaw = _context.Zestawy.FirstOrDefault(x => x.Id == zestawId);
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zestaw.ZamowienieId);
            if (zestaw != null && zestaw.StatusZestawu == StatusZestaw.Dodawany)
            {
                zamowienie.CenaSuma -= zestaw.CenaZestawu;
                _context.Zamowienia.Update(zamowienie);
                _context.Zestawy.Remove(_context.Zestawy.Find(zestawId));
                _context.SaveChanges();
            }

            return RedirectToAction("OrderMenu");
        }

        [HttpGet]
        [Route("/Menu/SelectZestaw/{zestawId}")]
        public IActionResult SelectZestaw(Guid zestawId)
        {
            var zestaw = _context.Zestawy.FirstOrDefault(x => x.Id == zestawId);
            return RedirectToAction("OrderMenu", new { selectedZamowienieId = zestaw.ZamowienieId, selectedZestawId = zestawId });
        }

        [HttpPost]
        [Route("/Menu/ConfirmZamowienie/{zamowienieId}")]
        public IActionResult ConfirmZamowienie(Guid zamowienieId)
        {
            var ddz = new List<DanieDoZestawu>();
            foreach (var zestaw in _context.Zestawy.ToList())
            {
                if (zestaw.ZamowienieId == zamowienieId)
                {
                    foreach (var daniedozestawu in _context.DaniaDoZestawu.ToList())
                    {
                        if (daniedozestawu.ZestawId == zestaw.Id)
                        {
                            ddz.Add(daniedozestawu);
                        }
                    }
                    //jezeli nie ma zadnych dan w zestawie to usuwamy zestaw
                    if (!ddz.Any())
                    {
                        _context.Zestawy.Remove(_context.Zestawy.Find(zestaw.Id));
                        _context.SaveChanges();
                    }
                    ddz.Clear();
                }
            }
            var zestawy = new List<Zestaw>();
            foreach (var zestaw in _context.Zestawy.Where(x=>x.ZamowienieId == zamowienieId).ToList())
            {
                if (zestaw.ZamowienieId == zamowienieId)
                {
                    zestawy.Add(zestaw);
                }
                //jezeli nie ma zadnych zestawow w zamowieniu to usuwamy zamowienie
                if (!zestawy.Any())
                {
                    _context.Zamowienia.Remove(_context.Zamowienia.Find(zamowienieId));
                    _context.SaveChanges();
                }
            }
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zamowienieId);
            if (zamowienie != null)
            {
                zamowienie.StatusZamowienie = StatusZamowienie.Oczekujace;
                zamowienie.CreateDate = DateTime.Now;
                _context.Zamowienia.Update(zamowienie);
                _context.SaveChanges();
                foreach (var zestaw in _context.Zestawy.ToList())
                {
                    if (zestaw.ZamowienieId == zamowienieId)
                    {
                        zestaw.StatusZestawu = StatusZestaw.Oczekujace;
                        zestaw.CreateDate = DateTime.Now;
                        _context.Zestawy.Update(zestaw);
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("OrderMenu");
        }

        [HttpGet]
        [Route("/Menu/AddDanieToZestaw/{danieId}/{zestawId}")]
        public IActionResult AddDanieToZestaw(Guid danieId, Guid zestawId)
        {
            var zestaw = _context.Zestawy.FirstOrDefault(x => x.Id == zestawId);
            if (zestaw == null) //Wyswietl błąd - należy wybrać zestaw
            {
                ViewData["message"] = "Proszę wybrać zestaw do którego należy dodać danie";
                ViewData["username"] = User.Identity.Name;
                var model = new OrderMenuViewModel()
                {
                    CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(), //potrzebne do menu
                    ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(), //potrzebne do menu
                    Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(), //potrzebne do menu
                    Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier) && (x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Dodawane)).ToList(), //wszystkie zamowienia tego uzytkownika, potrzebne do wybrania innego obecnie aktywnego zamowienia
                    Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie zestawy pasujace do obecnie wybranego zamowienia
                    DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie dania w zestawach tego uzytkownika
                    Symbole = _context.Symbole.ToList(),
                    SymboleDoDania = _context.SymboleDoDania.ToList()

                };
                return View("OrderMenu", model);
            }
            var danie = _context.Dania.FirstOrDefault(x => x.Id == danieId);
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zestaw.ZamowienieId);
            var ddz = new DanieDoZestawu()
            {
                DanieId = danieId,
                ZestawId = zestawId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                CreateDate = DateTime.Now,
                CreatedBy = "SYSTEM"
            };
            zestaw.CenaZestawu += danie.Cena;
            zamowienie.CenaSuma += danie.Cena;
            _context.DaniaDoZestawu.Add(ddz);
            _context.Zestawy.Update(zestaw);
            _context.Zamowienia.Update(zamowienie);
            _context.SaveChanges();

            return RedirectToAction("OrderMenu", new { selectedZamowienieId = zestaw.ZamowienieId, selectedZestawId = zestawId });
        }

        [HttpPost]
        [Route("/Menu/RemoveDanieFromZestaw/{ddzId}")]
        public IActionResult RemoveDanieFromZestaw(Guid ddzId)
        {
            var ddz = _context.DaniaDoZestawu.FirstOrDefault(x => x.Id == ddzId);
            _context.DaniaDoZestawu.Remove(_context.DaniaDoZestawu.Find(ddzId));
            var zestaw = _context.Zestawy.FirstOrDefault(x => x.Id == ddz.ZestawId);
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zestaw.ZamowienieId);
            var danieCena = _context.Dania.FirstOrDefault(x => x.Id == ddz.DanieId).Cena;
            
            zamowienie.CenaSuma -= zestaw.CenaZestawu;
            zestaw.CenaZestawu -= danieCena;
            _context.Zestawy.Update(zestaw);
            _context.Zamowienia.Update(zamowienie);
            _context.SaveChanges();
            return RedirectToAction("OrderMenu");
        }

        [HttpPost]
        [Route("/Menu/CloseZamowienie/{zamowienieId}")]
        public IActionResult CloseZamowienie(Guid zamowienieId)
        {
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zamowienieId);
            if (zamowienie != null)
            {
                zamowienie.StatusZamowienie = StatusZamowienie.Oplacane;
                zamowienie.DeleteDate = DateTime.Now;
                _context.Zamowienia.Update(zamowienie);
                _context.SaveChanges();
            }

            return RedirectToAction("OrderMenu");
        }

        //[HttpGet]
        //[Route("/Menu/CreateNewOrder/{zamowienieId}{danieId}")]
        //public IActionResult CreateNewOrder(Guid zamowienieId, Guid danieId)
        //{
        //    var zamowienie = new Zamowienie
        //    {
        //        ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        //        ZamowienieNr = _zamowienieNr++,
        //        StatusZamowienie = StatusZamowienie.Dodawane,
        //        CreatedBy = "SYSTEM",
        //    };
        //    _context.Zamowienia.Add(zamowienie);
        //    _context.SaveChanges();
        //    var zestaw = new Zestaw
        //    {
        //        StatusZestawu = StatusZestaw.Dodawany,
        //        CreatedBy = "SYSTEM",
        //        ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        //        ZamowienieId = zamowienie.Id,
        //    };
        //    _context.Zestawy.Add(zestaw);
        //    _context.SaveChanges();

        //    var danie = _context.Dania.FirstOrDefault(x => x.Id == danieId);
        //    if(danie!=null)
        //    {
        //        zamowienie.CenaSuma = danie.Cena;
        //        zestaw.CenaZestawu = danie.Cena;
        //        var ddz = new DanieDoZestawu
        //        {
        //            DanieId = danie.Id,
        //            ZestawId = zestaw.Id,
        //        };
        //        _context.DaniaDoZestawu.Add(ddz);
        //        _context.SaveChanges();
        //    }
        //    var model = new OrderMenuViewModel()
        //    {
        //        CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(), //potrzebne do menu
        //        ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(), //potrzebne do menu
        //        Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(), //potrzebne do menu
        //        Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(), //wszystkie zamowienia tego uzytkownika, potrzebne do wybrania innego obecnie aktywnego zamowienia
        //        Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier) && x.ZamowienieId == zamowienie.Id).ToList(), //wszystkie zestawy pasujace do obecnie wybranego zamowienia
        //        DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.ZestawId == zestaw.Id).ToList(), //wszystkie id dan pasujace do obecnie wybranego zamowienia(zestawow)
        //        SelectedZestawId = zestaw.Id, //zestaw do ktorego obecnie wybieramy
        //        SelectedZamowienieId = zamowienie.Id, //obecnie wybrane zamowienie
        //        DaniaWZestawie = new List<Danie>(),

        //    };
        //    foreach (var ddz in model.DaniaDoZestawow)
        //    {
        //        model.DaniaWZestawie.Add(_context.Dania.FirstOrDefault(x => x.Id == ddz.DanieId)); //wszystkie dania pasujace do obecnie wybranego zamowienia
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[Route("/Menu/RemoveDanie/{ddzId}")]
        //public IActionResult RemoveDanie(Guid ddzId)
        //{
        //    return Redirect;
        //}

        //[HttpGet]
        //[Route("/Menu/CreateNewOrder/")]
        //public IActionResult CreateNewOrder()
        //{
        //    var zamowienie = new Zamowienie
        //    {
        //        ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        //        ZamowienieNr = _zamowienieNr++,
        //        StatusZamowienie = StatusZamowienie.Dodawane,
        //        CreatedBy = "SYSTEM",
        //    };

        //    var zestaw = new Zestaw
        //    {
        //        StatusZestawu = StatusZestaw.Dodawany,
        //        CreatedBy = "SYSTEM",
        //        ZamawiajacyId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        //        ZamowienieId = zamowienie.Id,
        //    };

        //    _context.Zamowienia.Add(zamowienie);
        //    _context.Zestawy.Add(zestaw);
        //    _context.SaveChanges();
        //    var model = new OrderMenuViewModel()
        //    {
        //        CategoryList = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(),
        //        ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId != null).ToList(),
        //        Dania = _context.Dania.Where(x => x.CzyUpublicznione == true).ToList(),
        //        Zamowienia = _context.Zamowienia.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList(),
        //        Zestawy = _context.Zestawy.Where(x => x.ZamawiajacyId == User.FindFirstValue(ClaimTypes.NameIdentifier) && x.StatusZestawu==StatusZestaw.Dodawany).ToList(),
        //        DaniaDoZestawow = _context.DaniaDoZestawu.Where(x => x.ZestawId == zestaw.Id).ToList(),
        //        SelectedZestawId = zestaw.Id,
        //        SelectedZamowienieId = zamowienie.Id,
        //    };
        //    foreach(var ddz in model.DaniaDoZestawow)
        //    {
        //        model.DaniaWZestawie.Add(_context.Dania.FirstOrDefault(x => x.Id == ddz.DanieId));
        //    }
        //    return View(model);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
