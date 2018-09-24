using Forum.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Data.Pages.Messages
{
    public class IndexModel : PageModel
    {
        private readonly Forum.Data.GeneralContext _context;

        public IndexModel(Forum.Data.GeneralContext context)
        {
            _context = context;
        }

        public IList<Message> Message { get;set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Messages.ToListAsync();
        }
    }
}
