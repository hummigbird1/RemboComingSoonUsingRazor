using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RemboComingSoon.Data;
using RemboComingSoon.Models;

namespace RemboComingSoon.Pages.Emails
{
    public class IndexModel : PageModel
    {
        private readonly RemboComingSoon.Data.EmailContext _context;

        public IndexModel(RemboComingSoon.Data.EmailContext context)
        {
            _context = context;
        }

        public IList<Email> Email { get;set; }

        public async Task OnGetAsync()
        {
            Email = await _context.Email.ToListAsync();
        }
    }
}
