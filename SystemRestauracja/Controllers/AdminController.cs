using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using SystemRestauracja.Data;
using SystemRestauracja.Models.Admin;

namespace SystemRestauracja.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private RestaurantDbContext _context;
        private IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminController(RestaurantDbContext context, IServiceProvider serviceProvider, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        //CATEGORY CRUD

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new CategoryViewModel()
            {
                ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList(),
                HasParentCategory = false
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            var kat = _context.Kategorie.FirstOrDefault(x => x.Nazwa == model.CatName);
            if (kat == null && ModelState.IsValid)
            {
                var userManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                Kategoria k;
                if (!model.HasParentCategory)
                {
                    k = new Kategoria()
                    {
                        Nazwa = model.CatName,
                        CreateDate = DateTime.Now,
                        CreatedBy = userManager.GetUserId(User),
                        //musimy usunac wszystkie spacje i polskie znaki
                        NormalizedName = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.CatName.Replace(" ", ""))),
                        HasChildren = false,
                        //ParentCategory = _context.Kategorie.FirstOrDefault(x => x.Id == model.SelectedCategoryId)
                        //ParentCategoryId = new Guid("EF240E46-8CBF-4364-293F-08D7913EE9E3")
                    };
                }
                else
                {
                    k = new Kategoria()
                    {
                        Nazwa = model.CatName,
                        CreateDate = DateTime.Now,
                        CreatedBy = userManager.GetUserId(User),
                        NormalizedName = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.CatName.Replace(" ", ""))),
                        ParentCategoryId = model.SelectedCategoryId,
                        HasChildren = false,
                        //ParentCategory = _context.Kategorie.FirstOrDefault(x => x.Id == model.SelectedCategoryId)
                    };
                    var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == k.ParentCategoryId);
                    parentCat.HasChildren = true;
                    var daniaWithThatCategory = _context.Dania.Where(x => x.CategoryId == parentCat.Id).ToList();
                    if(daniaWithThatCategory.Any())
                    {
                        ModelState.AddModelError("Error", "Kategoria z daniami nie może mieć podkategorii. Usuń wszystkie dania z tej kategorii i spróbuj ponownie.");
                        model.ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList();
                        return View(model);
                    }
                    _context.Kategorie.Update(parentCat);
                }

                _context.Kategorie.Add(k);

                _context.SaveChanges();

            }
            else
            {
                if (kat != null)
                {
                    ModelState.AddModelError("Error", "Istnieje już kategoria o takiej nazwie.");
                }
                else
                {
                    ModelState.AddModelError("Error", "Niepoprawne dane.");
                }
                model.ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList();
                return View(model);
            }
            TempData["Success"] = "Nowa kategoria dodana pomyślnie.";
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public IActionResult ShowCategories(string sortOrder, string searchString, string currentFilter, int page = 1, int pageSize = 10)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.ParentCatSortParm = sortOrder == "parcat" ? "parcat_desc" : "parcat";
            decimal total = ((decimal)_context.Kategorie.Count() / (decimal)pageSize);
            ShowCategoriesViewModel model;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "name_desc":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderByDescending(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    };
                    break;
                case "date":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderBy(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    };
                    break;
                case "date_desc":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    };
                    break;
                case "parcat":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderBy(x => x.ParentCategory.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    };
                    break;
                case "parcat_desc":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderByDescending(x => x.ParentCategory.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    };
                    break;
                default:
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderBy(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    };
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString;
                model.Kategorie = model.Kategorie.Where(x => x.Nazwa.Contains(searchString)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                total = ((decimal)model.Kategorie.Count() / (decimal)pageSize);
            }

            model.currentPage = page;
            model.pageSize = pageSize;
            model.totalPages = (int)Math.Ceiling(total);

            //ShowCategoriesViewModel model = new ShowCategoriesViewModel()
            //{
            //    Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderByDescending(x => x.Nazwa).ToList(),
            //    Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderByDescending(x => x.Nazwa).ToList()
            //};
            return View(model);
        }

        [HttpGet]
        [Route("Admin/DeleteCategory/{categoryId}")]
        public IActionResult DeleteCategory(Guid categoryId, string returnUrl = null, int page = 1, int pageSize = 10)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var daniaWithThatCategory = _context.Dania.Where(x => x.CategoryId == categoryId).ToList();
            var catToDelete = _context.Kategorie.FirstOrDefault(x => x.Id == categoryId);
            if (catToDelete != null)
            {
                if (daniaWithThatCategory.Any())
                {
                    ModelState.AddModelError("Error", "Nie można usunąć kategorii z przypisanymi daniami.");

                    ShowCategoriesViewModel model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.OrderBy(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    };

                    return View("./ShowCategories", model);
                }
                if (catToDelete.HasChildren) //jezeli ma dzieci
                {
                    var ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId == categoryId).ToList();
                    foreach (var cat in ChildrenCategories)
                    {
                        //to sprawdz czy ktores ma danie
                        daniaWithThatCategory = _context.Dania.Where(x => x.CategoryId == cat.Id).ToList();
                        if (daniaWithThatCategory.Any())
                        {
                            ModelState.AddModelError("Error", "Nie można usunąć kategorii ponieważ podkategoria ma przypisane dania.");
                            ShowCategoriesViewModel model = new ShowCategoriesViewModel()
                            {
                                Kategorie = _context.Kategorie.OrderBy(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                            };

                            return View("./ShowCategories", model);
                        }
                        //a jeśli nie ma to usun wszystkie podkategorie
                        TempData["Success"] = "Kategoria i jej podkategorie usunięte pomyślnie.";
                        _context.Remove(_context.Kategorie.Find(cat.Id));
                    }
                    _context.Remove(_context.Kategorie.Find(categoryId));
                    _context.SaveChanges();
                }
                else
                {
                    TempData["Success"] = "Kategoria usunięta pomyślnie.";
                    _context.Remove(_context.Kategorie.Find(categoryId));
                    _context.SaveChanges();

                    //jezeli kategoria byla ostatnia z dzieci danej nadrzednej kategorii to trzeba zmienic flagę "haschildren" w nadrzednej kategorii
                    if (catToDelete.ParentCategoryId != null)
                    {
                        var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == catToDelete.ParentCategoryId);
                        //parentCat.HasChildren = false;
                        parentCat.HasChildren = (_context.Kategorie.FirstOrDefault(x => x.ParentCategoryId == parentCat.Id) != null);
                        _context.SaveChanges();
                    }

                }

            }
            else
            {
                TempData["Success"] = "Podana kategoria nie istnieje.";
            }
            
            return RedirectToAction("ShowCategories");
        }

        [HttpGet]
        [Route("Admin/EditCategory/{categoryId}")]
        public IActionResult EditCategory(Guid categoryId)
        {
            var catToEdit = _context.Kategorie.FirstOrDefault(x => x.Id == categoryId);
            if (catToEdit != null)
            {
                CategoryViewModel model = new CategoryViewModel()
                {
                    CatName = catToEdit.Nazwa,
                    HasParentCategory = (catToEdit.ParentCategoryId != null),
                    SelectedCategoryId = catToEdit.ParentCategoryId ?? Guid.Empty,
                    ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null && x.Id != categoryId).OrderBy(x => x.Nazwa).ToList(),
                };
                ViewData["Title"] = "Edytuj kategorię";
                return View("./AddCategory", model);
            }
            CategoryViewModel model2 = new CategoryViewModel()
            {
                ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null && x.Id != categoryId).OrderBy(x => x.Nazwa).ToList()
            };
            ModelState.AddModelError("Error", "Kategoria nie istnieje");
            return View("./AddCategory", model2);
        }

        [HttpPost]
        [Route("Admin/EditCategory/{categoryId}")]
        public IActionResult EditCategory(CategoryViewModel model, Guid categoryId)
        {

            var catToEdit = _context.Kategorie.FirstOrDefault(x => x.Id == categoryId);
            if (catToEdit != null && ModelState.IsValid)
            {
                var catByName = _context.Kategorie.FirstOrDefault(x => x.Nazwa == model.CatName);

                if (catByName != null && (catByName.Id != catToEdit.Id))
                {
                    ModelState.AddModelError("Error", "Istnieje już kategoria o takiej nazwie.");
                    model.ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList();
                    model.CatName = catToEdit.Nazwa;
                    return View("./AddCategory", model);
                }

                catToEdit.Nazwa = model.CatName;

                if (model.HasParentCategory)
                {
                    catToEdit.ParentCategoryId = model.SelectedCategoryId;
                    var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == model.SelectedCategoryId);
                    parentCat.HasChildren = true;
                    var daniaWithThatCategory = _context.Dania.Where(x => x.CategoryId == parentCat.Id).ToList();
                    if (daniaWithThatCategory.Any())
                    {
                        ModelState.AddModelError("Error", "Kategoria z daniami nie może mieć podkategorii. Usuń wszystkie dania z tej kategorii i spróbuj ponownie.");
                        model.ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList();
                        return View(model);
                    }

                    _context.Kategorie.Update(parentCat);
                }
                else
                {
                    //var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == catToEdit.ParentCategoryId);
                    var childrencat = _context.Kategorie.Where(x => x.ParentCategoryId == catToEdit.Id).ToList();
                    bool stillHasChildren = false;
                    foreach (var ccat in childrencat)
                    {
                        if (ccat.ParentCategoryId == catToEdit.Id)
                        {
                            stillHasChildren = true;
                        }
                    }
                    _context.Kategorie.Update(catToEdit);
                    catToEdit.ParentCategoryId = null;
                }
                catToEdit.NormalizedName = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.CatName.Replace(" ", "")));
                _context.Kategorie.Update(catToEdit);
                _context.SaveChanges();
                TempData["Success"] = "Kategoria edytowana pomyślnie.";
                return RedirectToAction("ShowCategories");
            }
            else
            {
                ModelState.AddModelError("Error", "Niepoprawne dane.");
                model.ParentCategoryChoice = _context.Kategorie.Where(x => x.ParentCategoryId == null).ToList();
                return View("./AddCategory", model);
            }
        }

        //DANIE CRUD

        [HttpGet]
        public IActionResult AddDanie()
        {
            var model = new DanieViewModel()
            {
                CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList(),

            };

            ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDanie(DanieViewModel model)
        {
            var danie = _context.Dania.FirstOrDefault(x => x.Nazwa == model.DanieName);
            if (danie == null && ModelState.IsValid)
            {
                var userManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                Danie d = new Danie()
                {
                    Nazwa = model.DanieName,
                    NormalizedNazwa = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.DanieName.Replace(" ", ""))),
                    OpisDania = model.Description,
                    CreateDate = DateTime.Now,
                    CreatedBy = userManager.GetUserId(User),
                    CategoryId = model.SelectedCategoryId,
                    //CzyOstre = model.IsSpicy,
                    //CzyWeganskie = model.IsVegan,
                    Cena = model.Price,
                    CzyUpublicznione = model.IsPublic
                };

                _context.Dania.Add(d);

                _context.SaveChanges();

                if (model.WybraneIdSymboli != null)
                {
                    foreach (var guid in model.WybraneIdSymboli)
                    {
                        SymbolDoDania sdd = new SymbolDoDania()
                        {
                            SymbolId = guid,
                            DanieId = d.Id,
                            CreateDate = DateTime.Now,
                            CreatedBy = userManager.GetUserId(User),
                            Danie = d,
                            Symbol = _context.Symbole.FirstOrDefault(x => x.Id == guid)
                        };
                        _context.SymboleDoDania.Add(sdd);
                        _context.SaveChanges();
                    }
                }

            }
            else
            {
                if (danie != null)
                {
                    ModelState.AddModelError("Error", "Istnieje już danie o takiej nazwie.");
                }
                else
                {
                    ModelState.AddModelError("Error", "Niepoprawne dane.");
                }
                model.CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList();
                ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
                return View(model);
            }
            TempData["Success"] = "Danie dodane pomyślnie.";
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public IActionResult ShowDania(string sortOrder, string searchString, string currentFilter, int page = 1, int pageSize = 7)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            ViewBag.CatSortParm = sortOrder == "cat" ? "cat_desc" : "cat";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";
            decimal total = ((decimal)_context.Dania.Count() / (decimal)pageSize);
            ShowDaniaViewModel model;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            switch (sortOrder)
            {
                case "name_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "date":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "date_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "price":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.Cena).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "price_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Cena).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "cat":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.Category.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "cat_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Category.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                default:
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                model.Dania = model.Dania.Where(x => x.Nazwa.ToLower().Contains(searchString)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                total = ((decimal)(model.Dania.Count())) / (decimal)pageSize;
            }

            model.currentPage = page;
            model.pageSize = pageSize;
            model.totalPages = (int)Math.Ceiling(total);

            return View(model);
        }

        [HttpGet]
        [Route("Admin/DeleteDanie/{danieId}")]
        public IActionResult DeleteDanie(Guid danieId, string searchString, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var danieToDelete = _context.Dania.FirstOrDefault(x => x.Id == danieId);

            if (danieToDelete != null)
            {
                var list = _context.SymboleDoDania.Where(x => x.DanieId == danieToDelete.Id).ToList();
                foreach (var value in list)
                {
                    _context.SymboleDoDania.Remove(value);
                }
                _context.Remove(_context.Dania.Find(danieId));
                _context.SaveChanges();
                TempData["Success"] = "Danie usunięte pomyślnie.";
            }
            else
            {
                TempData["Success"] = "Podane danie nie istnieje.";
            }

            return RedirectToAction("ShowDania", new { searchString = searchString });
        }

        [HttpGet]
        [Route("Admin/EditDanie/{danieId}")]
        public IActionResult EditDanie(Guid danieId)
        {

            var danieToEdit = _context.Dania.FirstOrDefault(x => x.Id == danieId);
            if (danieToEdit != null)
            {
                DanieViewModel model = new DanieViewModel()
                {
                    DanieName = danieToEdit.Nazwa,
                    SelectedCategoryId = danieToEdit.CategoryId,
                    Description = danieToEdit.OpisDania,
                    CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList(),
                    IsPublic = danieToEdit.CzyUpublicznione,
                    //IsSpicy = danieToEdit.CzyOstre,
                    //IsVegan = danieToEdit.CzyWeganskie,
                    Price = danieToEdit.Cena
                };

                model.CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList();
                ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
                ViewData["Title"] = "Dodaj kategorię";
                return View("./AddDanie", model);
            }
            DanieViewModel model2 = new DanieViewModel()
            {
                CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList()
            };
            ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
            ModelState.AddModelError("Error", "Danie nie istnieje");
            return View("./AddDanie", model2);
        }

        [HttpPost]
        [Route("Admin/EditDanie/{danieId}")]
        public IActionResult EditDanie(DanieViewModel model, Guid danieId)
        {


            var danieToEdit = _context.Dania.FirstOrDefault(x => x.Id == danieId);
            if (danieToEdit != null && ModelState.IsValid)
            {

                var danieByName = _context.Dania.FirstOrDefault(x => x.Nazwa == model.DanieName);

                if (danieByName != null && (danieByName.Id != danieToEdit.Id))
                {
                    ModelState.AddModelError("Error", "Istnieje już danie o takiej nazwie.");
                    model.CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList();
                    ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
                    return View("./AddDanie", model);
                }

                danieToEdit.Nazwa = model.DanieName;
                danieToEdit.NormalizedNazwa = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.DanieName.Replace(" ", "")));
                danieToEdit.OpisDania = model.Description;
                danieToEdit.CategoryId = model.SelectedCategoryId;
                danieToEdit.CzyUpublicznione = model.IsPublic;
                //danieToEdit.CzyOstre = model.IsSpicy;
                //danieToEdit.CzyWeganskie = model.IsVegan;
                danieToEdit.Cena = model.Price;
                _context.Dania.Update(danieToEdit);
                _context.SaveChanges();

                var list = _context.SymboleDoDania.Where(x => x.DanieId == danieToEdit.Id).ToList();
                foreach (var value in list)
                {
                    _context.SymboleDoDania.Remove(value);
                }
                _context.SaveChanges();

                if (model.WybraneIdSymboli != null)
                {
                    var userManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                    foreach (var guid in model.WybraneIdSymboli)
                    {
                        var symbolDoDania = new SymbolDoDania()
                        {
                            SymbolId = guid,
                            DanieId = danieToEdit.Id,
                            CreateDate = DateTime.Now,
                            CreatedBy = userManager.GetUserId(User),
                            Danie = danieToEdit,
                            Symbol = _context.Symbole.FirstOrDefault(x => x.Id == guid)
                        };

                        var c = _context.SymboleDoDania.FirstOrDefault(x => x.SymbolId == symbolDoDania.SymbolId && x.DanieId == symbolDoDania.DanieId);
                        if (c == null)
                        {
                            _context.SymboleDoDania.Add(symbolDoDania);
                        }
                        _context.SaveChanges();
                    }
                }
                TempData["Success"] = "Danie edytowane pomyślnie.";
                return RedirectToAction("ShowDania");
            }
            //cos poszlo nie tak, odswiez strone
            ModelState.AddModelError("Error", "Niepoprawne dane.");
            model.CategoryChoice = _context.Kategorie.Where(x => x.HasChildren == false).ToList();
            ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
            return View("./AddDanie", model);
        }

        //USER CRUD

        [HttpGet]
        [Route("Admin/AddUser")]
        public async Task<IActionResult> AddUserAsync()
        {
            var model = new UserViewModel()
            {
            };
            return await Task.Run(() => View("./AddUser", model));
        }

        [HttpPost]
        [Route("Admin/AddUser")]
        public async Task<IActionResult> AddUserAsync(UserViewModel model)
        {
            //do użytku TYLKO do dodawania nowych stolików w restauracji, przynajmniej na tym etapie rozwoju aplikacji.
            //Nazwa "User" jest ogólna by dodać możliwość późniejszego rozwoju aplikacji.
            if (ModelState.IsValid)
            {
                var UserManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
                var newUser = new UserAccount
                {
                    UserName = model.UserName,
                    IsActive = "true",
                    StatusStolika = StatusStolik.Pusty,
                };

                string userPassword = model.Password;
                var user = await UserManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    var createUser = await UserManager.CreateAsync(newUser, userPassword);
                    if (createUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(newUser, "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Użytkownik istnieje już w bazie danych.");
                    return await Task.Run(() => RedirectToAction("Index"));

                }

                TempData["Success"] = "Użytkownik dodany pomyślnie.";
                return await Task.Run(() => RedirectToAction("Index"));
            }
            ModelState.AddModelError("Error", "Niepoprawne dane.");
            //coś poszło nie tak, odśwież stronę
            return await Task.Run(() => View("./AddUser"));
        }

        [HttpGet]
        public IActionResult ShowUsers(string sortOrder, string searchString, string currentFilter, int page = 1, int pageSize = 10)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StatusSortParm = sortOrder == "stat" ? "stat_desc" : "stat";
            decimal total = ((decimal)_context.Users.Count() / (decimal)pageSize);
            ShowUsersViewModel model;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "name_desc":
                    model = new ShowUsersViewModel()
                    {
                        Users = _context.Users.OrderByDescending(x => x.UserName).ToList()
                    };
                    break;
                case "stat":
                    model = new ShowUsersViewModel()
                    {
                        Users = _context.Users.OrderBy(x => x.StatusStolika).ToList()
                    };
                    break;
                case "stat_desc":
                    model = new ShowUsersViewModel()
                    {
                        Users = _context.Users.OrderByDescending(x => x.StatusStolika).ToList()
                    };
                    break;
                default:
                    model = new ShowUsersViewModel()
                    {
                        Users = _context.Users.OrderByDescending(x => x.UserName).ToList()
                    };
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                model.Users = model.Users.Where(x => x.UserName.ToLower().Contains(searchString)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                total = ((decimal)(model.Users.Count())) / (decimal)pageSize;
            }

            model.currentPage = page;
            model.pageSize = pageSize;
            model.totalPages = (int)Math.Ceiling(total);

            return View(model);
        }

        [HttpPost]
        [Route("Admin/DeleteUser/{userId}")]
        public IActionResult DeleteUser(string userId, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var userToDelete = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (userToDelete != null)
            {
                userToDelete.IsActive = "false";
                _context.Users.Update(userToDelete);
                _context.SaveChanges();
                TempData["Success"] = "Użytkownik usunięty pomyślnie.";
            }
            else
            {
                TempData["Success"] = "Użytkownik nie istnieje";
            }

            
            return View();
        }

        [HttpGet]
        [Route("Admin/EditUser/{userId}")]
        public async Task<IActionResult> EditUserAsync(string userId)
        {

            var UserManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
            var userToEdit = await UserManager.FindByIdAsync(userId);
            if (userToEdit != null)
            {
                UserViewModel model = new UserViewModel()
                {
                    UserName = userToEdit.UserName,
                    Status = userToEdit.StatusStolika,
                    Password = ""
                };
                ViewData["Title"] = "Edytuj użytkownika";
                return View("./AddUser", model);
            }
            ModelState.AddModelError("Error", "Użytkownik nie istnieje");
            return View("./AddUser");
        }

        [HttpPost]
        [Route("Admin/EditUser/{userId}")]
        public async Task<IActionResult> EditUserAsync(UserViewModel model, string userId)
        {

            var UserManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
            var userToEdit = await UserManager.FindByIdAsync(userId);
            if (userToEdit != null && ModelState.IsValid)
            {
                userToEdit.StatusStolika = StatusStolik.Pusty;
                userToEdit.UserName = model.UserName;
                userToEdit.PasswordHash = UserManager.PasswordHasher.HashPassword(userToEdit, model.Password);
                var UserByName = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                if (UserByName != null && (UserByName.Id != userToEdit.Id))
                {
                    ModelState.AddModelError("Error", "Istnieje już użytkownik o takiej nazwie.");
                    return View("./AddUser", model);
                }

                await UserManager.UpdateAsync(userToEdit);

                TempData["Success"] = "Użytkownik edytowany pomyślnie.";
                return RedirectToAction("ShowUsers");
            }
            ModelState.AddModelError("Error", "Niepoprawne dane.");
            //cos poszlo nie tak, odswiez strone
            return View("./AddUser", model);
        }

        [HttpGet]
        public IActionResult ShowPending(string sortOrder, string currentFilter, int page = 1, int pageSize = 10)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "date"; //domyślnie od najstarszego zamówienia
            ViewBag.StatusSortParm = sortOrder == "stat" ? "stat_desc" : "stat";
            ViewBag.TableSortParm = sortOrder == "table" ? "table_desc" : "table";
            decimal total = ((decimal)_context.Users.Count() / (decimal)pageSize);
            ShowPendingViewModel model;

            switch (sortOrder)
            {
                case "price":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderBy(x => x.CenaSuma).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderBy(x => x.CenaZestawu).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "price_desc":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderByDescending(x => x.CenaSuma).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderByDescending(x => x.CenaZestawu).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "stat":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderBy(x => x.StatusZamowienie).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderBy(x => x.StatusZestawu).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "stat_desc":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderByDescending(x => x.StatusZamowienie).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderByDescending(x => x.StatusZestawu).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "date_desc":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderBy(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderByDescending(x => x.CreateDate).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "table_desc":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderByDescending(x => x.Zamawiajacy.UserName).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderByDescending(x => x.Zamawiajacy.UserName).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                case "table":
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderBy(x => x.Zamawiajacy.UserName).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderBy(x => x.Zamawiajacy.UserName).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
                default:
                    model = new ShowPendingViewModel()
                    {
                        //Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane)
                        //.OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderByDescending(x => x.CreateDate).ToList(),
                        Dania = _context.Dania.ToList(),
                        DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                        Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
                    };
                    break;
            }

            model.currentPage = page;
            model.pageSize = pageSize;
            model.totalPages = (int)Math.Ceiling(total);

            return View(model);
        }

        //[HttpGet]
        //public IActionResult ShowOpenOrders()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("Admin/CloseZamowienie/{zamowienieId}")]
        //public IActionResult CloseZamowienie(Guid zamowienieId)
        //{
        //    var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zamowienieId);
        //    if (zamowienie != null)
        //    {
        //        zamowienie.StatusZamowienie = StatusZamowienie.Usuniete;
        //        zamowienie.DeleteDate = DateTime.Now;
        //        _context.Zamowienia.Update(zamowienie);
        //        _context.SaveChanges();
        //    }
        //    return RedirectToAction("ShowPending");
        //}

        [HttpGet]
        [Route("Admin/CloseZestaw/{zestawId}")]
        public IActionResult CloseZestaw(Guid zestawId)
        {
            var zestaw = _context.Zestawy.FirstOrDefault(x => x.Id == zestawId);
            if (zestaw != null)
            {
                zestaw.StatusZestawu = StatusZestaw.Wydane;
                zestaw.DeleteDate = DateTime.Now;
                _context.Zestawy.Update(zestaw);
                _context.SaveChanges();
                var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zestaw.ZamowienieId);
                bool wszystkieZestawyWydane = true;
                foreach (var z in _context.Zestawy)
                {
                    if (z.ZamowienieId == zamowienie.Id && z.StatusZestawu != StatusZestaw.Wydane)
                    {
                        wszystkieZestawyWydane = false;
                    }
                }
                if (wszystkieZestawyWydane)
                {
                    zamowienie.StatusZamowienie = StatusZamowienie.Usuniete;
                    zamowienie.DeleteDate = DateTime.Now;
                    _context.Zamowienia.Update(zamowienie);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ShowPending");
        }

        [HttpGet]
        public IActionResult AddSymbol()
        {
            var model = new SymbolViewModel() { };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSymbol(SymbolViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var files = HttpContext.Request.Form.Files;
                string uniqueFileName = null;
                Symbol s = null;
                var symbol = _context.Symbole.FirstOrDefault(x => x.Nazwa == model.SymbolName);

                if (symbol == null)
                {
                    s = new Symbol()
                    {
                        Nazwa = model.SymbolName,
                        //FontId = model.SymbolFontId,
                        //Color = model.SymbolColor
                    };
                    _context.Symbole.Add(s);
                    _context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("Error", "Istnieje już danie o takiej nazwie.");
                    ViewData["Edit"] = "true";
                    return View("./AddSymbol", model);
                }
                if (model.SymbolImage != null && model.SymbolImage.IsImage())
                {
                    try
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = s.Id.ToString() + "_" + model.SymbolImage.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        //using (var fileStream = new FileStream(filePath, FileMode.Create))
                        //{
                        //    model.SymbolImage.CopyTo(fileStream);
                        //}
                        var filestream = new FileStream(filePath, FileMode.Create);

                        model.SymbolImage.CopyTo(filestream);
                        filestream.Close();
                    }
                    catch (Exception e)
                    {

                    }
                }
                s.ObrazUrl = uniqueFileName;
                _context.Symbole.Update(s);
                _context.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("Error", "Niepoprawne dane.");
                return View();
            }

            TempData["Success"] = "Pomyślnie dodano symbol.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Route("Admin/EditSymbol/{symbolId}")]
        public IActionResult EditSymbol(Guid symbolId)
        {
            var symbolToEdit = _context.Symbole.FirstOrDefault(x => x.Id == symbolId);
            if (symbolToEdit != null)
            {
                SymbolViewModel model = new SymbolViewModel()
                {
                    //SymbolColor = symbolToEdit.Color,
                    //SymbolFontId = symbolToEdit.FontId,
                    SymbolName = symbolToEdit.Nazwa,
                };
                ViewData["Edit"] = "true";
                return View("./AddSymbol", model);
            }
            ModelState.AddModelError("Error", "Symbol nie istnieje");

            return View("./AddSymbol");
        }

        [HttpPost]
        [Route("/Admin/EditSymbol/{symbolId}")]
        public IActionResult EditSymbol(SymbolViewModel model, Guid symbolId)
        {
            if (ModelState.IsValid)
            {
                var symbolToEdit = _context.Symbole.FirstOrDefault(x => x.Id == symbolId);

                if (symbolToEdit != null)
                {

                    var symbolByName = _context.Symbole.FirstOrDefault(x => x.Nazwa == model.SymbolName);

                    if (symbolByName != null && (symbolByName.Id != symbolToEdit.Id))
                    {
                        ModelState.AddModelError("Error", "Istnieje już symbol o takiej nazwie.");
                        ViewData["Edit"] = "true";
                        return View("./AddSymbol", model);
                    }
                    symbolToEdit.Nazwa = model.SymbolName;
                    //symbol.Color = model.SymbolColor;
                    //symbol.FontId = model.SymbolFontId;
                    _context.Symbole.Update(symbolToEdit);
                    _context.SaveChanges();


                    //var files = HttpContext.Request.Form.Files;
                    string uniqueFileName = null;
                    //if (symbol == null)
                    //{
                    //    s = new Symbol()
                    //    {
                    //        Nazwa = model.SymbolName,
                    //        //FontId = model.SymbolFontId,
                    //        //Color = model.SymbolColor
                    //    };
                    //    _context.Symbole.Add(s);
                    //    _context.SaveChanges();
                    //}
                    //else
                    //{
                    if (model.SymbolImage != null && model.SymbolImage.IsImage())
                    {
                        try
                        {
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                            uniqueFileName = symbolToEdit.Id.ToString() + "_" + model.SymbolImage.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            //using (var fileStream = new FileStream(filePath, FileMode.Create))
                            //{
                            //    model.SymbolImage.CopyTo(fileStream);
                            //}
                            var filestream = new FileStream(filePath, FileMode.Create);

                            model.SymbolImage.CopyTo(filestream);
                            filestream.Close();
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    symbolToEdit.ObrazUrl = uniqueFileName;
                    _context.Symbole.Update(symbolToEdit);
                    _context.SaveChanges();
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Niepoprawne dane.");
                ViewData["Edit"] = "true";
                return View("./AddSymbol", model);
            }
            TempData["Success"] = "Pomyślnie edytowano symbol.";
            return RedirectToAction("ShowSymbols");
        }

        [HttpGet]
        [Route("/Admin/DeleteSymbol/{symbolId}")]
        public IActionResult DeleteSymbol(Guid symbolId)
        {
            var symbolToDelete = _context.Symbole.FirstOrDefault(x => x.Id == symbolId);

            if (symbolToDelete != null)
            {
                _context.Remove(_context.Symbole.Find(symbolId));
                foreach (var symbolDoDania in _context.SymboleDoDania.ToList())
                {
                    if (symbolDoDania.SymbolId == symbolId)
                    {
                        _context.Remove(symbolDoDania);
                    }
                }
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, symbolToDelete.ObrazUrl);
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
                _context.SaveChanges();
                TempData["Success"] = "Pomyślnie usunięto symbol.";
            }
            else
            {
                TempData["Success"] = "Symbol nie istnieje.";
            }
            return RedirectToAction("ShowSymbols");
        }

        [HttpGet]
        public IActionResult ShowSymbols(string sortOrder, string searchString, string currentFilter, int page = 1, int pageSize = 7)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            decimal total = ((decimal)_context.Symbole.Count() / (decimal)pageSize);
            ShowSymbolsViewModel model;
            switch (sortOrder)
            {
                case "name_desc":
                    model = new ShowSymbolsViewModel()
                    {
                        Symbole = _context.Symbole.OrderByDescending(x=>x.Nazwa).ToList(),
                    };
                    break;
                default:
                    model = new ShowSymbolsViewModel()
                    {
                        Symbole = _context.Symbole.OrderBy(x => x.Nazwa).ToList(),
                    };
                    break;
            }

            model.currentPage = page;
            model.pageSize = pageSize;
            model.totalPages = (int)Math.Ceiling(total);

            return View(model);
        }

        [HttpGet]
        public IActionResult GenerateReportDania()
        {
            return View();
        }
    }
}
