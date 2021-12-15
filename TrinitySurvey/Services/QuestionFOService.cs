using TrinitySurvey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TrinitySurvey.Services
{
    public class QuestionFOService
    {
        private readonly IMongoCollection<QuestionFO> _questions;

        public QuestionFOService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _questions = database.GetCollection<QuestionFO>("Questions_5optionCustom");
        }

        public List<QuestionFO> Get() =>
            _questions.Find(question => true).ToList();

        public QuestionFO Get(string id) =>
            _questions.Find<QuestionFO>(question => question.Id == id).FirstOrDefault();

        public QuestionFO Create(QuestionFO question)
        {
            _questions.InsertOne(question);
            return question;
        }
        public IList<QuestionFO> Read() =>
            _questions.Find(sub => true).ToList();

        public QuestionFO Find(string id) =>
            _questions.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(QuestionFO submission) =>
            _questions.ReplaceOne(sub => sub.Id == submission.Id, submission);

        public void Delete(string id) =>
            _questions.DeleteOne(sub => sub.Id == id);
    }
}
