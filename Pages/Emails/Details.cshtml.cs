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
    public class DetailsModel : PageModel
    {
        private readonly RemboComingSoon.Data.EmailContext _context;

        public DetailsModel(RemboComingSoon.Data.EmailContext context)
        {
            _context = context;
        }

        public Email Email { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Email = await _context.Email.FirstOrDefaultAsync(m => m.ID == id);

            if (Email == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
