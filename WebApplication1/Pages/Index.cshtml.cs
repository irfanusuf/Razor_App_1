using Microsoft.AspNetCore.Mvc.RazorPages;   

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    public void OnGet()    
    {
      Console.WriteLine("Somebody sent me a get Request!");
    }

    public void OnPost()
    {


    }

}
