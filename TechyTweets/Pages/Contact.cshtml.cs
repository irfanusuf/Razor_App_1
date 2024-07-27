using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using TechyTweets.models;



namespace TechyTweets.Pages;

    public class ContactModel : PageModel
    {


        private readonly IMongoCollection<Contact> _contactsCollection;

        public ContactModel(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetSection("MongoDB")["ConnectionString"]);

            var database = mongoClient.GetDatabase(configuration.GetSection("MongoDB")["DatabaseName"]);
            
            _contactsCollection = database.GetCollection<Contact>("Contacts");
        }


        
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Query { get; set; }
        public bool IsSuccess { get; set; } = false;
      
        public void OnGet()
        {
             Console.WriteLine("get request from contact page");
        }


        public IActionResult OnPost(){

            if(ModelState.IsValid){

                Console.WriteLine(Query);


                   var contact = new Contact
                {
                    UserName = UserName,
                    Email = Email,
                    Query = Query
                };
                
                _contactsCollection.InsertOne(contact);
                IsSuccess =true;
            }

        
            return Page();

        }
       
    }

