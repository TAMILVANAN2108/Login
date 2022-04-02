using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Login.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Loginpage Model { get; set; }
      

        public LoginModel( SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(String ReturnUri=null)

        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Model.Email,Model.Password,Model.Rememberme,false);
                if (result.Succeeded)
                {
                   if(ReturnUri==null||ReturnUri=="/")
                    {
                        return RedirectToPage("Index");
                    }
                   else
                    {
                       
                        return RedirectToPage(ReturnUri);
                    }
                  
                }
                ModelState.AddModelError("","Username and Pasword InCORRECT!!!");
            }
            return Page();
        }
    }
}
