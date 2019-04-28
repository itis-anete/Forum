using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Web.Controllers
{
    public class ThemeController : Controller
    {
        private IThemeRepository _repository;

        public ThemeController(IThemeRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public IActionResult Index(int? forumId)
        {
            return View(_repository.GetAllThemes(forumId));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theme = _repository.GetById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(theme);
        }

        [HttpGet]
        public IActionResult Create(int? forumId)
        {
            ViewData["ForumId"] = forumId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Theme theme)
        {
            try
            {
                await _repository.Add(theme);
            }
            catch
            {
                return StatusCode(500);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theme = _repository.GetById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(theme);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Theme theme)
        {
            if (id != theme.Id || theme == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.Edit(theme);
            }
            catch
            {
                return StatusCode(500);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theme = _repository.GetById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(theme);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var theme = _repository.GetById(id);

            try
            {
                await _repository.Delete(theme);
            }
            catch
            {
                return StatusCode(500);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

