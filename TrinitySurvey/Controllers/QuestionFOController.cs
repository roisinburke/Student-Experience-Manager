using TrinitySurvey.Models;
using TrinitySurvey.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System;

namespace TrinitySurvey.Controllers
{
    public class QuestionsFOController : Controller
    {
        private readonly QuestionFOService _questionService;
        private readonly ResponseFOService _responseService;

        public QuestionsFOController(QuestionFOService questionService, ResponseFOService responseService)
        {
            _questionService = questionService;
            _responseService = responseService;
        }

        public ActionResult<IList<Response>> ResponseList(string id) => View(_responseService.Get(id));

        public ActionResult<IList<QuestionFO>> QuestionList() => View(_questionService.Get());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult<QuestionFO> Create(QuestionFO question)
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