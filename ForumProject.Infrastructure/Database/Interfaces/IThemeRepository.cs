using ForumProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumProject.Infrastructure.Database.Interfaces
{
    public interface IThemeRepository
    {
        Task Add(Theme theme);
        Theme GetById(int? themeId);
        Theme GetByName(string name);
        Task Edit(Theme theme);
        Task Delete(Theme theme);
        IEnumerable<Theme> GetAllThemes(int? forumId);
    }
}
