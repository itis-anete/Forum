using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using ForumProject.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumProject.Web.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository _repository;

        public CommentController(CommentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int? topicId)
        {
            return View(_repository.GetAllComments(topicId));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _repository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpGet]
        public IActionResult Create(int? topicId)
        {
            ViewData["TopicId"] = topicId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            try
            {
                await _repository.Add(comment);
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

            var comment = _repository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Comment comment)
        {
            if (id != comment.Id || comment == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.Edit(comment);
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

            var comment = _repository.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = _repository.GetById(id);

            try
            {
                await _repository.Delete(comment);
            }
            catch
            {
                return StatusCode(500);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

