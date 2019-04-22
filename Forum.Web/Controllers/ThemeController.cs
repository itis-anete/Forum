using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Connection.Services;

namespace Forum.Web.Controllers
{
    public class ThemeController : Controller
    {
        private readonly ThemeService _themeService;

        public ThemeController()
        {
            _themeService = new ThemeService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTheme(string name, string description, int forumId)
        {
            var created = _themeService.Create(name, description, forumId);
            if (!created)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult CreateTheme(int? forumId)
        {
            ViewBag.ForumId = forumId;
            return View();
        }
    }
}