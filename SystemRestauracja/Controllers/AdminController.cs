﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public AdminController(RestaurantDbContext context, IServiceProvider serviceProvider)
        {
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
            if (kat == null)
            {
                Kategoria k;
                if (!model.HasParentCategory)
                {
                    k = new Kategoria()
                    {
                        Nazwa = model.CatName,
                        CreateDate = DateTime.Now,
                        CreatedBy = "SYSTEM",
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
                        CreatedBy = "SYSTEM",
                        NormalizedName = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.CatName.Replace(" ", ""))),
                        ParentCategoryId = model.SelectedCategoryId,
                        HasChildren = false,
                        //ParentCategory = _context.Kategorie.FirstOrDefault(x => x.Id == model.SelectedCategoryId)
                    };
                    var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == k.ParentCategoryId);
                    parentCat.HasChildren = true;
                    _context.Kategorie.Update(parentCat);
                }

                _context.Kategorie.Add(k);

                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public IActionResult ShowCategories(string sortOrder, string searchString, string currentFilter, int page=1, int pageSize=10)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchString = searchString;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";
            decimal total = ((decimal)_context.Kategorie.Count() / (decimal)pageSize);
            ShowCategoriesViewModel model;
            if(searchString!=null)
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
                        Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderByDescending(x => x.Nazwa).Skip((page-1)*pageSize).Take(pageSize).ToList(),
                        Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderByDescending(x => x.Nazwa).ToList()
                    };
                    break;
                case "date":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderBy(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderBy(x => x.CreateDate).ToList()
                    };
                    break;
                case "date_desc":
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderByDescending(x => x.CreateDate).ToList()
                    };
                    break;
                default:
                    model = new ShowCategoriesViewModel()
                    {
                        Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderBy(x => x.Nazwa).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                        Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderBy(x => x.Nazwa).ToList()
                    };
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                model.Kategorie = model.Kategorie.Concat(model.Podkategorie).ToList();
                model.Kategorie = model.Kategorie.Where(x => x.Nazwa.ToLower().Contains(searchString)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                total = ((decimal)(model.Kategorie.Count())) / (decimal)pageSize;
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
        public IActionResult DeleteCategory(Guid categoryId, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ShowCategoriesViewModel model = new ShowCategoriesViewModel()
            {
                Kategorie = _context.Kategorie.Where(x => x.ParentCategoryId == null).OrderBy(x => x.Nazwa).ToList(),
                Podkategorie = _context.Kategorie.Where(x => x.ParentCategoryId != null).OrderBy(x => x.Nazwa).ToList()
            };
            var daniaWithThatCategory = _context.Dania.Where(x => x.CategoryId == categoryId).ToList();
            var catToDelete = _context.Kategorie.FirstOrDefault(x => x.Id == categoryId);
            if (catToDelete != null)
            {
                if (daniaWithThatCategory.Any())
                {
                    ModelState.AddModelError("Error", "Nie można usunąć kategorii z przypisanymi daniami.");

                    return View("./ShowCategories", model);
                }
                if (catToDelete.HasChildren) //jezeli ma dzieci
                {
                    //to usun wszystkie podkategorie
                    var ChildrenCategories = _context.Kategorie.Where(x => x.ParentCategoryId == categoryId).ToList();
                    foreach (var cat in ChildrenCategories)
                    {
                        _context.Remove(_context.Kategorie.Find(cat.Id));
                    }
                    _context.Remove(_context.Kategorie.Find(categoryId));
                    _context.SaveChanges();
                }
                else
                {
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
            return RedirectToAction("ShowCategories");
        }

        [HttpGet]
        [Route("Admin/EditCategory/{categoryId}")]
        public IActionResult EditCategory(Guid categoryId, string returnUrl = null)
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
                return View("./AddCategory", model);
            }
            return View("./AddCategory");
        }

        [HttpPost]
        [Route("Admin/EditCategory/{categoryId}")]
        public IActionResult EditCategory(CategoryViewModel model, Guid categoryId, string returnUrl = null)
        {

            var catToEdit = _context.Kategorie.FirstOrDefault(x => x.Id == categoryId);
            if (catToEdit != null)
            {
                catToEdit.Nazwa = model.CatName;
                if (model.HasParentCategory)
                {
                    catToEdit.ParentCategoryId = model.SelectedCategoryId;
                    var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == model.SelectedCategoryId);
                    parentCat.HasChildren = true;
                    _context.Kategorie.Update(parentCat);
                }
                else
                {
                    var parentCat = _context.Kategorie.FirstOrDefault(x => x.Id == catToEdit.ParentCategoryId);
                    var childrencat = _context.Kategorie.Where(x => x.ParentCategoryId == parentCat.Id);
                    bool stillHasChildren = false;
                    foreach (var ccat in childrencat)
                    {
                        if (ccat.ParentCategoryId == parentCat.Id)
                        {
                            stillHasChildren = true;
                        }
                    }
                    _context.Kategorie.Update(parentCat);
                    catToEdit.ParentCategoryId = null;
                }
                catToEdit.NormalizedName = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.CatName.Replace(" ", "")));
                _context.Kategorie.Update(catToEdit);
                _context.SaveChanges();
                return RedirectToAction("ShowCategories");
            }
            //cos poszlo nie tak, odswiez strone
            return View("./AddCategory");
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
                Danie d = new Danie()
                {
                    Nazwa = model.DanieName,
                    NormalizedNazwa = Encoding.ASCII.GetString(Encoding.GetEncoding("Cyrillic").GetBytes(model.DanieName.Replace(" ", ""))),
                    OpisDania = model.Description,
                    CreateDate = DateTime.Now,
                    CreatedBy = "SYSTEM",
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
                            CreatedBy = "SYSTEM",
                            Danie = d,
                            Symbol = _context.Symbole.FirstOrDefault(x => x.Id == guid)
                        };
                        _context.SymboleDoDania.Add(sdd);
                        _context.SaveChanges();
                    }
                }

            }
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public IActionResult ShowDania(string sortOrder, string searchString, string currentFilter, int page = 1, int pageSize = 10)
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
            switch(sortOrder)
            {
                case "name_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Nazwa).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "date":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.CreateDate).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "date_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.CreateDate).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "price":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.Cena).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "price_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Cena).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "cat":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x=>x.Category.Nazwa).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                case "cat_desc":
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderByDescending(x => x.Category.Nazwa).ToList(),
                        Kategorie = _context.Kategorie.ToList(),
                        SymboleDoDania = _context.SymboleDoDania.ToList(),
                        Symbole = _context.Symbole.ToList()
                    };
                    break;
                default:
                    model = new ShowDaniaViewModel()
                    {
                        Dania = _context.Dania.OrderBy(x => x.Nazwa).ToList(),
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

        [HttpPost]
        public IActionResult DeleteDanie(Guid danieId, string returnUrl = null)
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
            }

            return View();
        }

        [HttpGet]
        [Route("Admin/EditDanie/{danieId}")]
        public IActionResult EditDanie(Guid danieId, string returnUrl = null)
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


                ViewBag.Symbole = _context.Symbole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nazwa }).ToList();
                return View("./AddDanie", model);
            }
            return View("./AddDanie");
        }

        [HttpPost]
        [Route("Admin/EditDanie/{danieId}")]
        public IActionResult EditDanie(DanieViewModel model, Guid danieId, string returnUrl = null)
        {


            var danieToEdit = _context.Dania.FirstOrDefault(x => x.Id == danieId);
            if (danieToEdit != null)
            {
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

                foreach (var guid in model.WybraneIdSymboli)
                {
                    var symbolDoDania = new SymbolDoDania()
                    {
                        SymbolId = guid,
                        DanieId = danieToEdit.Id,
                        CreateDate = DateTime.Now,
                        CreatedBy = "SYSTEM",
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

                return RedirectToAction("ShowDania");
            }
            //cos poszlo nie tak, odswiez strone
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
                user.IsActive = "true";
                _context.Users.Update(user);
                _context.SaveChanges();

            }

            return await Task.Run(() => RedirectToAction("Index"));
        }

        [HttpGet]
        public IActionResult ShowUsers()
        {
            ShowUsersViewModel model = new ShowUsersViewModel()
            {
                Users = _context.Users.Where(x => x.IsActive != "false").ToList()
            };
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
            }

            return View();
        }

        [HttpGet]
        [Route("Admin/EditUser/{userId}")]
        public async Task<IActionResult> EditUserAsync(string userId, string returnUrl = null)
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
                return View("./AddUser", model);
            }
            return View("./AddUser");
        }

        [HttpPost]
        [Route("Admin/EditUser/{userId}")]
        public async Task<IActionResult> EditUserAsync(UserViewModel model, string userId, string returnUrl = null)
        {

            var UserManager = _serviceProvider.GetRequiredService<UserManager<UserAccount>>();
            var userToEdit = await UserManager.FindByIdAsync(userId);
            if (userToEdit != null)
            {
                userToEdit.StatusStolika = StatusStolik.Pusty;
                userToEdit.UserName = model.UserName;
                userToEdit.PasswordHash = UserManager.PasswordHasher.HashPassword(userToEdit, model.Password);

                await UserManager.UpdateAsync(userToEdit);
                ShowUsersViewModel model2 = new ShowUsersViewModel()
                {
                    Users = _context.Users.Where(x => x.IsActive != "false").ToList()
                };
                return View("./ShowUsers", model2);
            }
            //cos poszlo nie tak, odswiez strone
            return View("./AddUser", model);
        }

        [HttpGet]
        public IActionResult ShowPending()
        {
            var model = new ShowPendingViewModel()
            {
                Zamowienia = _context.Zamowienia.Where(x => x.StatusZamowienie == StatusZamowienie.Oczekujace || x.StatusZamowienie == StatusZamowienie.Oplacane).OrderBy(x => x.CreateDate).Take(10).ToList(),
                Zestawy = _context.Zestawy.Where(x => x.StatusZestawu == StatusZestaw.Oczekujace).OrderBy(x => x.CreateDate).ToList(),
                Dania = _context.Dania.ToList(),
                DaniaDoZestawow = _context.DaniaDoZestawu.ToList(),
                Uzytkownicy = _context.Users.Where(x => x.IsActive != "false").ToList(),
            };

            return View(model);
        }

        [HttpGet]
        [Route("Admin/CloseZamowienie/{zamowienieId}")]
        public IActionResult CloseZamowienie(Guid zamowienieId)
        {
            var zamowienie = _context.Zamowienia.FirstOrDefault(x => x.Id == zamowienieId);
            if (zamowienie != null)
            {
                zamowienie.StatusZamowienie = StatusZamowienie.Usuniete;
                zamowienie.DeleteDate = DateTime.Now;
                _context.Zamowienia.Update(zamowienie);
                _context.SaveChanges();
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
            var symbol = _context.Symbole.FirstOrDefault(x => x.Nazwa == model.SymbolName);
            if (symbol == null)
            {
                Symbol s = new Symbol()
                {
                    Nazwa = model.SymbolName,
                    FontId = model.SymbolFontId,
                    Color = model.SymbolColor
                };
                _context.Symbole.Add(s);
                _context.SaveChanges();
            }
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
                    SymbolColor = symbolToEdit.Color,
                    SymbolFontId = symbolToEdit.FontId,
                    SymbolName = symbolToEdit.Nazwa
                };
                return View("./AddSymbol", model);
            }
            return View("./AddSymbol");
        }

        [HttpPost]
        [Route("/Admin/EditSymbol/{symbolId}")]
        public IActionResult EditSymbol(SymbolViewModel model, Guid symbolId)
        {
            var symbol = _context.Symbole.FirstOrDefault(x => x.Id == symbolId);
            if (symbol != null)
            {
                symbol.Nazwa = model.SymbolName;
                symbol.Color = model.SymbolColor;
                symbol.FontId = model.SymbolFontId;
                _context.Symbole.Update(symbol);
                _context.SaveChanges();
                return RedirectToAction("ShowSymbols");
            }
            //cos poszlo nie tak, odswiez strone
            return View("./AddSymbol", model);
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
                _context.SaveChanges();
            }

            return RedirectToAction("ShowSymbols");
        }

        [HttpGet]
        public IActionResult ShowSymbols()
        {
            ShowSymbolsViewModel model = new ShowSymbolsViewModel()
            {
                Symbole = _context.Symbole.ToList(),
            };
            return View(model);
        }

    }
}
