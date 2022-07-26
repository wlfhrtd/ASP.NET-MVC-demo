using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models;
using Mvc.Services.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;


namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppLogging<HomeController> logger;

        public HomeController(IAppLogging<HomeController> appLogging)
        {
            logger = appLogging;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewBag.Message = "ASP.NET MVC samples";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "email to strmbld@gmail.com with any questions";
            return View();
        }

        public IActionResult Control()
        {
            Guitar model = new()
            {
                Brand = "Charvel",
                Model = "Metal Shredder",
                WhammyBarType = "Floyd Rose",
                Description = "Death to all but metal",
                Strings = new List<string> { "E", "A", "D", "G", "B", "E" },
                HasWhammyBar = true,
            };

            return View(model);
        }

        public IActionResult Variables()
        {
            Guitar g = new()
            {
                Brand = "Gibson",
                Model = "Les Paul",
                Description = "Very cool guitar",
                Strings = new List<string> { "E", "A", "D", "G", "B", "E" },
                HasWhammyBar = false,
            };

            return View(g);
        }

        public IActionResult Loops()
        {
            List<Guitar> ls = new()
            {
                new() { Brand = "Fender", Model = "Strat", HasWhammyBar = true },
                new() { Brand = "Gibson", Model = "Les Paul", HasWhammyBar = false },
                new() { Brand = "Charvel", Model = "Metal", HasWhammyBar = true },
                new() { Brand = "Fender", Model = "Telecaster", HasWhammyBar = false },
            };

            return View(ls);
        }

        public IActionResult HtmlHelper()
        {
            Guitar g = new()
            {
                Brand = "Gibson",
                Model = "Les Paul",
                HasWhammyBar = false,
            };

            return View(g);
        }

        [HttpPost]
        public IActionResult HtmlHelper(Guitar obj)
        {
            if (ModelState.IsValid)
            {
                return View("GuitarSaved", obj);
            }
            return View(obj);
        }

        public IActionResult CodeBlocks()
        {
            return View();
        }

        public IActionResult CodeNuggets()
        {
            var model = new Product();
            model.Id = 123;
            return View(model);
        }

        public IActionResult ExplicitMarkup()
        {
            Guitar g = new()
            {
                Brand = "Gibson",
                Model = "Les Paul",
                Strings = new List<string> { "E", "A", "D", "G", "B", "E" }
            };

            return View(g);
        }

        public IActionResult Comments()
        {
            return View();
        }

        public IActionResult StandardHtmlHelpers()
        {
            return View();
        }

        public IActionResult StronglyTypedHtmlHelpers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StronglyTypedHtmlHelpers(LoginViewModel model)
        {
            return View(model);
        }

        public IActionResult TemplatedHtmlHelpers(LoginViewModel model)
        {
            return View(model);
        }

        public IActionResult InlineFunctions()
        {
            return View();
        }

        public IActionResult ActionLinks()
        {
            return View();
        }

        public IActionResult FormTagHelpers()
        {
            AdvancedContact model = new() { AllowContactSpecialOffers = true };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormTagHelpers(AdvancedContact model)
        {
            if (ModelState.IsValid)
            {
                return View("FormTagHelpersThanks", model);
            }

            return View(model);
        }

        public IActionResult SelectTag()
        {
            GuitarBrandViewModel m = new()
            {
                Brands = new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "", Text = "Select a brand" },
                    new SelectListItem() { Value = "1", Text = "Gibson" },
                    new SelectListItem() { Value = "2", Text = "Charvel" },
                    new SelectListItem() { Value = "3", Text = "Ibanez" },
                    new SelectListItem() { Value = "4", Text = "Jackson" },
                },
            };

            return View(m);
        }

        public IActionResult SelectTag(GuitarBrandViewModel model)
        {
            model.Brands = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "", Text = "Select a brand" },
                new SelectListItem() { Value = "1", Text = "Gibson" },
                new SelectListItem() { Value = "2", Text = "Charvel" },
                new SelectListItem() { Value = "3", Text = "Ibanez" },
                new SelectListItem() { Value = "4", Text = "Jackson" },
            };

            if (model.SelectedBrandId != 0)
            {
                model.SelectedBrand = (from b in model.Brands
                                       where b.Value == model.SelectedBrandId.ToString()
                                       select new GuitarBrand
                                       {
                                           Id = int.Parse(b.Value),
                                           Name = b.Text,
                                       }).FirstOrDefault();
            }

            return View(model);
        }

        public IActionResult Validation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validation(ContactForValidation model)
        {
            if (ModelState.IsValid)
            {
                return View("ValidationThanks");
            }

            return View();
        }

        public IActionResult CacheSelectList()
        {
            var model = new FormWithCacheViewModel { MyListIsCached = "Nothing" };
            return View(model);
        }

        [HttpPost]
        public IActionResult CacheSelectList(FormWithCacheViewModel model)
        {
            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult TagCloud()
        {
            return View();
        }

        public IActionResult Comparison()
        {
            return View();
        }

        public IActionResult CustomTagHelpers()
        {
            return View();
        }

        public IActionResult LookupList()
        {
            return View();
        }

        public IActionResult Areas()
        {
            return View();
        }

        public IActionResult ColumnListTagHelper()
        {
            DataTable dataTable = new();
            using (SqlConnection connection = new(
                @"Server=.,5433;Database=Mvc6RecipesSharedDb;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=true"))
            {
                string sql = "SELECT TOP(20) UserName, AvatarURL, Country, CreateDate, ProfileViews FROM [dbo].[Artist]";
                using (SqlCommand cmd = new(sql, connection))
                {
                    using (SqlDataAdapter dataAdapter = new(cmd))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            List<Artist> artists = new();
            foreach (var item in dataTable.AsEnumerable())
            {
                artists.Add(new Artist
                {
                    UserName = item.Field<string>("UserName"),
                    AvatarUrl = item.Field<string>("AvatarURL"),
                    Country = item.Field<string>("Country"),
                    CreateDate = item.Field<DateTime>("CreateDate"),
                    ProfileViews = item.Field<long>("ProfileViews"),
                });
            }

            return View(artists);
        }
    }
}
