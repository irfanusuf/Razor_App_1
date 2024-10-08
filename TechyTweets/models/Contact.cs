﻿
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechyTweets.models
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
    }
}
