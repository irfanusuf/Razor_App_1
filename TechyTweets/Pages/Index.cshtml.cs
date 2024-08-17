using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TechyTweets.Pages;

public class IndexModel : PageModel
{

    public void OnGet()
    {
        Console.WriteLine("someone sends get request to main page ");
    }

    public IActionResult OnPost(){

        return Page();
    }


}
