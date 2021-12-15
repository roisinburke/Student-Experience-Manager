using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrinitySurvey.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        
        public string question_id { get; set; }

        public string question_body  { get; set; }
        public string module_id { get; set; }
        public string _p_key { get; set; }

    }
}
