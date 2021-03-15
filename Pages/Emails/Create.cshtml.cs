using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RemboComingSoon.Data;
using RemboComingSoon.Models;

namespace RemboComingSoon.Pages.Emails
{
    public class CreateModel : PageModel
    {
        private readonly RemboComingSoon.Data.EmailContext _context;

        public CreateModel(RemboComingSoon.Data.EmailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Email Email { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Email.Add(Email);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
