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

            // We set the confirmation in the TempData (instead of the ViewData) - TempData seems to be the more recommended way for doing this kind of thing
            // as it appears it has autromatisms to be cleared automatically once it has been used
            // Also it is the only way to make this work with the more commonly recommended so called "Post-Redirect-Get" (PRG) pattern
            // Be aware though that also the HTML Part needs to use TempData now instead of the ViewData
            TempData["confirmation"] = $" Thank you for signing up. Information will be sent to {EmailAddress}";

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

            // Since we are redirecting now to our page (instead of re-rendering it) ther entire post data (bound property and modelstate) is no longer available 
            // and therefore the page appears "reset" although in fact it is an entirely new page (as if we came to it the first time)
            // This approach seems to be the more recommended way as it behaves properly with browser "back navigation" and reload functions
            return RedirectToPage();
        }
    }
}
