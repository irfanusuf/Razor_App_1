using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechyTweets.models;

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get; set;}
    public string Username {get ; set;}
    public string Email {get ; set;}
    public string Password {get ; set;}
    public string Address {get; set;}
    public string Landmark {get; set;}
    public string Designation {get; set;}
    public string CurrentSalary {get; set;} 
    public string HighestQual {get ;set;} 
    }











