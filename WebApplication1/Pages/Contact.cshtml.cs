using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Pages;

    public class ContactModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Query { get; set; }

        public bool IsSuccess {get; set;} = false  ;


        public void OnGet()
        {

            Console.WriteLine("get contact page");
        }


        public IActionResult OnPost(){

            if(ModelState.IsValid){
                Console.WriteLine(UserName);
                Console.WriteLine(Email);
                Console.WriteLine(Query);

                IsSuccess = true;

               return RedirectToPage("Index");
            }
            else{
                Console.WriteLine("model state not valid");
            }


            return Page();

        }
       
    }

