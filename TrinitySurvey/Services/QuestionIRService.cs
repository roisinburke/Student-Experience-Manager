using TrinitySurvey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TrinitySurvey.Services
{
    public class QuestionIRService
    {
        private readonly IMongoCollection<Question> _questions;

        public QuestionIRService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _questions = database.GetCollection<Question>("Questions_IntegerResponse");
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
        public IList<Question> Read() =>
            _questions.Find(sub => true).ToList();

        public Question Find(string id) =>
            _questions.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Question submission) =>
            _questions.ReplaceOne(sub => sub.Id == submission.Id, submission);

        public void Delete(string id) =>
            _questions.DeleteOne(sub => sub.Id == id);
    }
}
