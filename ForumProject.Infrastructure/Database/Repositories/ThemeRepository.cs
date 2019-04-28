using ForumProject.Core.Entities;
using ForumProject.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly ForumDbContext _context;

        public ThemeRepository(ForumDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Theme theme)
        {
            //theme.Id = 0; если сущность будет добавляться изнутри форума, то придется применять данную строчку
            await _context.Themes.AddAsync(theme);
            await _context.SaveChangesAsync();
        }

        public Theme GetById(int? themeId)
        {
            var theme = _context.Themes.Find(themeId);

            return theme;
        }

        public Theme GetByName(string name)
        {
            var theme = _context.Themes.Find(name);

            return theme;
        }

        public async Task Edit(Theme theme)
        {
            var entity = _context.Themes.Find(theme.Id);
            if (entity == null)
                await _context.Themes.AddAsync(theme);
            else
            {
                entity = theme;
                //_context.Themes.FirstOrDefault(x => x.Id == theme.Id).Name = theme.Name;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Theme theme)
        {
            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Theme> GetAllThemes(int? forumId)
        {
            var themes = _context.Themes
                .AsEnumerable()
                .Where(theme => theme.ForumId == forumId);
            return themes;
        }
    }
}
