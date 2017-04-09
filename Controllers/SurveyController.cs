using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteMP.Models;
using TesteMP.Services;

namespace TesteMP.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IEmailSender _emailSender;

        public SurveyController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        public IActionResult Save(Survey model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            var sendGenericEmail = true;

            if(model.HTML > 6 && model.CSS > 6 && model.Javascript > 6)
            {
                SendEmail(model.Email,"Front End");
                sendGenericEmail = false;
            }
            
            if(model.Python >6 && model.Django > 6)
            {
                SendEmail(model.Email,"Back End");
                sendGenericEmail = false;
            }

            if(model.iOS > 6 && model.Android > 6)
            {
                SendEmail(model.Email,"Mobile");
                sendGenericEmail = false;
            }

            if(sendGenericEmail)
                SendEmail(model.Email,"");

            return View("Sucess",model.Name);
        }

        private void SendEmail(string email,string type)
        {
            _emailSender.SendEmailAsync(email,
            "Obrigado por se candidatar",
            $"Obrigado por se candidatar, assim que tivermos uma vaga disponível para programador {type} entraremos em contato.");
        }

    }
}
