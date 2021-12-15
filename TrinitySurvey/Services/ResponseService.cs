using TrinitySurvey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Threading.Tasks;

namespace TrinitySurvey.Services
{
    public class ResponseService
    {
        private readonly IMongoCollection<Response> _responses;

        public ResponseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _responses = database.GetCollection<Response>("Responses_Emoji");
        }


        public IList<Response> Get(string id) => _responses.Find(response => response.question_id == id).ToList();

       

    }
}
