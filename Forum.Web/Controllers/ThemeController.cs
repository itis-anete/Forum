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
        public ActionResult Create(string name, string description, int forumId)
        {
            var created = _themeService.Create(name, description, forumId);
            if (!created)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult Create(int? forumId)
        {
            ViewBag.ForumId = forumId;
            return View();
        }

        public ActionResult Edit(string name, string newName, string newDescription)
        {
            var edited = _themeService.Edit(name, newName, newDescription);
            if (!edited)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        public ActionResult Delete(string name)
        {
            return !_themeService.Delete(name) ? StatusCode(500) : Ok();
        }

        [HttpGet]
        public ActionResult GetThemeByName(string name)
        {
            try
            {
                var theme = _themeService.GetByName(name);
                if (theme == null)
                {
                    return StatusCode(500);
                }
                return Ok(theme);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAllThemes()
        {
            try
            {
                var themes = _themeService.GetAllTheme();
                return Ok(themes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpGet]
        //public ActionResult GetAllThemesFromForum(string forumName)
        //{

        //}
    }
}