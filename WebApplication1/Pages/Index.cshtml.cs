using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel   
{
    public void OnGet()
    {
            Console.WriteLine("heelo somebody sent me a get request");
    }
}
