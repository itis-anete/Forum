using Forum.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Data.Pages.SubforumView
{
    public class SubforumModel : PageModel
    {
        private readonly GeneralContext dbContext;

        public SubforumModel(GeneralContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int forumid)
        {
            this.SubjectsWithMessages = this.dbContext.Subjects
                .Where(x => x.Id == forumid)
                .Include(x => x.Messages).ToList();
        }

        public List<Subject> SubjectsWithMessages { get; set; }
    }
}