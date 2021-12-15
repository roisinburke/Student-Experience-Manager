﻿using TrinitySurvey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TrinitySurvey.Services
{
    public class ResponseIRService
    {
        private readonly IMongoCollection<Response> _responses;

        public ResponseIRService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _responses = database.GetCollection<Response>("Responses_Integer");
        }
        public IList<Response> Get(string id) => _responses.Find(response => response.question_id == id).ToList();

    }
}
