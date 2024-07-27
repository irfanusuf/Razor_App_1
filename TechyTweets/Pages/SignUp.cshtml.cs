using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using TechyTweets.models;

namespace TechyTweets.Pages;

public class SignUpModel : PageModel
{


    private readonly IMongoCollection<User> _usersCollection;

    public SignUpModel(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetSection("MongoDB")["ConnectionString"]);

        var database = mongoClient.GetDatabase(configuration.GetSection("MongoDB")["DatabaseName"]);

        _usersCollection = database.GetCollection<User>("Users");
    }




    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Password { get; set; }
    [BindProperty]
    public string Address { get; set; }
    [BindProperty]
    public string Landmark { get; set; }
    [BindProperty]
    public string Designation { get; set; }
    [BindProperty]
    public string CurrentSalary { get; set; }
    [BindProperty]
    public string HighestQual { get; set; }



    public IActionResult OnPost()
    {


        if (ModelState.IsValid)
        {
            var user = new User
            {

                Username = Username,
                Email = Email,
                Password = Password,
                Landmark = Landmark,
                Address = Address,
                Designation = Designation,
                CurrentSalary = CurrentSalary,
                HighestQual = HighestQual
            };

            _usersCollection.InsertOne(user);

        }
        return Page();
    }
}

