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
            await _repository.Add(forum);
            return RedirectToAction(nameof(Index));
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

            await _repository.Edit(forum);

            return RedirectToAction(nameof(Index));
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
    
        //Тут используется вьюха Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum = _repository.GetByIdAsync(id);
            await _repository.Delete(forum.Result);
            return RedirectToAction(nameof(Index));
        }

        //Переделать  в GetThemesFromForum

        //[HttpGet]
        //public IActionResult GetLiquidsFromCategory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var liquids = _repository.GetLiquidsFromCategory(id);
        //    var category = _repository.GetByIdAsync(id).Result;
        //    ViewData["CategoryName"] = category.Name;
        //    ViewData["CategoryId"] = category.Id;
        //    return View(liquids);
        //}

    }
}