using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;
using TechyTweets.models;

namespace TechyTweets.Pages
{

    public class LoginModel : PageModel
    {

    private readonly IMongoCollection<User> _usersCollection;

    public LoginModel(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetSection("MongoDB")["ConnectionString"]);

        var database = mongoClient.GetDatabase(configuration.GetSection("MongoDB")["DatabaseName"]);

        _usersCollection = database.GetCollection<User>("Users");
    }

            [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }

        public string Message { get; set; } = "";


        public void OnGet()
        {
        }


        public IActionResult OnPost(){

        if(ModelState.IsValid){

            var user = _usersCollection.Find(r => r.Email == Email).FirstOrDefault();

            Console.WriteLine("user :" + " " + user);

            var hashedPassword = user.Password;
            Console.WriteLine("hashedPassword:" + " " + hashedPassword); 
             
            
            var verifypass = BCrypt.Net.BCrypt.Verify(Password , hashedPassword);

             Console.WriteLine(verifypass);
            if(verifypass){
                    Message = "Logged In  Succesfully!";
            }else{
                Message = "Incorrect Password!";
            }

              Console.WriteLine(Message);
        } 
            return Page();
        }


    }
}
