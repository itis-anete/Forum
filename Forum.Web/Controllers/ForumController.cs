using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Forum.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Forum.Connection.Services;

namespace Forum.Web.Controllers
{
    [Route("api/[controller]")]
    public class ForumController : Controller
    {
        private readonly ForumService _forumService;
        private readonly PostService _postService;

        public ForumController()
        {
            _forumService = new ForumService();
            _postService = new PostService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateForum(int id, string name, string description)
        {
            var created = _forumService.Create(id, name, description);
            if (!created)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult EditForum(string name, string newName, string description)
        {
            var edited = _forumService.Edit(name, newName, description);
            if (!edited)
            {
                return StatusCode(500);
            }
            return Ok();
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForum(string name)
        {
            return !_forumService.Delete(name) ? StatusCode(500) : Ok();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult GetForumByName(string name)
        {
            try
            {
                var forum = _forumService.GetByName(name);
                if (forum == null)
                {
                    return StatusCode(500);
                }
                return Ok(forum);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetByForum(id);
            var ft = new ForumTopic { Forum = forum, Topics = posts };
            return Ok(ft);
        }

        [HttpGet("[action]")]
        //[ValidateAntiForgeryToken]
        public ActionResult GetAllForums()
        {
            try
            {
                var forums = _forumService.GetAllForums();
                return Ok(forums);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}