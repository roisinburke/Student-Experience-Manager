using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrinitySurvey.Models
{
    public class Response
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        public string question_id { get; set; }

        public string student_id { get; set; }
        public string response { get; set; }
        public string question_comment{ get; set; }
        public string _p_key { get; set; }

    }
}
