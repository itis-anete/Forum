using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Web.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository _repository;

        public ForumController(IForumRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllForums());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = _repository.GetByIdAsync(id).Result;

            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Forum forum)
        {
            try
            {
                await _repository.Add(forum);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = _repository.GetByIdAsync(id).Result;

            if (forum == null)
            {
                return NotFound();
            }
            return View(forum);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Forum forum)
        {
            if (id != forum.Id || forum == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.Edit(forum);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return StatusCode(500);
            }     
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = _repository.GetByIdAsync(id).Result;

            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var forum = _repository.GetByIdAsync(id);
                await _repository.Delete(forum.Result);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        public IActionResult GetThemesFromForum(int? forumId)
        {
            if (forumId == null)
            {
                return NotFound();
            }

            var themes = _repository.GetThemesFromForum(forumId);
            return View(themes);
        }

    }
}

