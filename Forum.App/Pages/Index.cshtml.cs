using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Data.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GeneralContext dbContext;

        public IndexModel(GeneralContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Subforums = this.dbContext.Forums.Include(x => x.Subjects).ToList();
        }

        public IEnumerable<Forum.Infrastructure.Entities.Subforum> Subforums { get; set; }
    }
}
