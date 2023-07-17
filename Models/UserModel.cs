﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace WebApplication1.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string ? Firstname { get; set; }
        public string ? Lastname { get; set; }
        public string ? Email { get; set; }
        public string ? Password { get; set; }
    }
}
