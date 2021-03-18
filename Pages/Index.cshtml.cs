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
        public string EmailAddress { get; set; }

        // Binding the property that is of type "Email" is a little bit different than binding a property that has a primitive type as "string"
        // https://www.learnrazorpages.com/razor-pages/model-binding#binding-complex-objects

        //Your original property definition: 
        //public Email EmailAddress { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // However since you are receiving a simple string as property now, you need to create a model for storing it in the database
            // in any way that suits your needs. 
            // A simple example in your case would be:
            var emailDbModel = new Email
            {
                // Now just take the property value that is bound from the razor page input and assign it to the model property
                EmailAddress = EmailAddress
            };
            _emailDbContext.Email.Add(emailDbModel);
            await _emailDbContext.SaveChangesAsync();

            return (IActionResult)(ViewData["confirmation"] = $" Thank you for signing up. Information will be sent to {EmailAddress}");
        }
    }
}
