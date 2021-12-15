using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrinitySurvey.Models
{
    public class QuestionFO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string question_id { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string option5 { get; set; }
        public string question_body { get; set; }
        public string module_id { get; set; }
        public string _p_key { get; set; }

    }
}
