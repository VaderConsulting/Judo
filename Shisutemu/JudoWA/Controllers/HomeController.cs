using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;


namespace JudoWA.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _Env;

        public HomeController(IHostingEnvironment env)
        {
            _Env = env;

        }

        public IActionResult Index()
        {
            string WebRootPath = _Env.WebRootPath;
            string BannerPath = System.IO.Path.Combine(WebRootPath, @"images/banner");
            int BannerFileCount = System.IO.Directory.EnumerateFiles(BannerPath).Count();
            ViewData["BannerFiles"] = System.IO.Directory.EnumerateFiles(BannerPath);

            ViewData["BannerFileCount"] = BannerFileCount;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Judo Western Australia (Inc.) - About us";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Judo Western Australia (Inc.) - Contact Details";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
