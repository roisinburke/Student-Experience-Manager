using TrinitySurvey.Models;
using TrinitySurvey.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System;
using System.Threading.Tasks;

namespace TrinitySurvey.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly QuestionService _questionService;
        private readonly ResponseService _responseService;

        public QuestionsController(QuestionService questionService, ResponseService responseService)
        {
            _questionService = questionService;
            _responseService = responseService;
        }
        


        public ActionResult<IList<Question>> QuestionList() => View(_questionService.Get());

        public ActionResult<IList<Response>> ResponseList(string id) => View(_responseService.Get(id));


        [HttpGet]
        public ActionResult Create() => View();
        public ActionResult<Question> Create(Question question)
        {
            Random rnd = new Random();
            int number_id = rnd.Next(9999);
            string text_id = number_id.ToString();
            question.question_id = text_id;
            string keyString = "My Project";
            question._p_key = keyString;

            if (ModelState.IsValid)
            {
                _questionService.Create(question);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}