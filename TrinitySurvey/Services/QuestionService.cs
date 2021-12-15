using TrinitySurvey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TrinitySurvey.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questions;

        public QuestionService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _questions = database.GetCollection<Question>("Questions_Emoji_Response");
        }

        public List<Question> Get() =>
            _questions.Find(question => true).ToList();

        public Question Get(string id) =>
            _questions.Find<Question>(question => question.Id == id).FirstOrDefault();

        public Question Create(Question question)
        {
            _questions.InsertOne(question);
            return question;
        }
       
    }
}
