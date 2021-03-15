using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RemboComingSoon.Data;
using RemboComingSoon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RemboComingSoon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RemboComingSoon.Data.EmailContext _emailDbContext;

        public IndexModel(EmailContext emailDbbContext)
        {
            _emailDbContext = emailDbbContext;
        }

        public void OnGet()
        {

        }
        [BindProperty]
        [Required(ErrorMessage = "Email is required...")]
        public Email EmailAddress { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            _emailDbContext.Email.Add(EmailAddress);
            await _emailDbContext.SaveChangesAsync();

            return (IActionResult)(ViewData["confirmation"] = $" Thank you for signing up. Information will be sent to {EmailAddress}");
        }
    }
}
