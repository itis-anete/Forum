﻿using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly ForumDbContext _context;

        public ForumRepository(ForumDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Forum forum)
        {
            await _context.Forums.AddAsync(forum);
            await _context.SaveChangesAsync();
        }

        public async Task<Forum> GetByIdAsync(int? forumId)
        {
            return await _context.Forums.FindAsync(forumId);
        }

        public async Task<Forum> GetByNameAsync(string name)
        {
            var category = await _context.Forums.FindAsync(name);

            return category;
        }

        public async Task Edit(Forum forum)
        {
            var entity = await _context.Forums.FindAsync(forum.Id);
            if (entity == null)
                await _context.Forums.AddAsync(forum);
            else
            {
                entity.Name = forum.Name;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Forum forum)
        {
            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Forum> GetAll()
        {
            var categories = _context.Forums.AsEnumerable();

            return categories;
        }

        //public IEnumerable<Theme> GetThemesFromForum(int? forumId)
        //{
        //    var themes = _context.Themes.Where(x => x.forumId == forumId);

        //    return themes;
        //}
    }
}
