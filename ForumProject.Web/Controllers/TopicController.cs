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
    public class TopicController : Controller
    {
        private ITopicRepository _repository;

        public TopicController(ITopicRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_repository.GetAllTopics());
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = _repository.GetById(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpGet]
        public IActionResult Create(int? themeId)
        {
            ViewData["ThemeId"] = themeId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Topic topic)
        {
            try
            {
                await _repository.Add(topic);
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

            var topic = _repository.GetById(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Topic topic)
        {
            if (id != topic.Id || topic == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.Edit(topic);
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

            var topic = _repository.GetById(id);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var topic = _repository.GetById(id);

            try
            {
                await _repository.Delete(topic);
            }
            catch
            {
                return StatusCode(500);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


