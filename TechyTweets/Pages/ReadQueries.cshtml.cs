using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using TechyTweets.models;
using System.Collections.Generic;

namespace TechyTweets.Pages
{
    public class ReadQueriesModel : PageModel
    {
        private readonly IMongoCollection<Contact> _contactsCollection;

        public ReadQueriesModel(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetSection("MongoDB")["ConnectionString"]);
            var database = mongoClient.GetDatabase(configuration.GetSection("MongoDB")["DatabaseName"]);
            _contactsCollection = database.GetCollection<Contact>("Contacts");
        }

        public List<Contact> Contacts { get; set; }

        public void OnGet()
        {
         
            Contacts = _contactsCollection.Find(static _ => true).ToList();
        }
    }
}
