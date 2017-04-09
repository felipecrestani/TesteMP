using Xunit;
using TesteMP.Controllers;
using TesteMP.Models;
using TesteMP.Services;
using Microsoft.AspNetCore.Mvc;

namespace TesteMP.Tests
{
    public class TestSendSurvey
    {
        [Fact]
        public void TestControllerSaveSurvey()
        {
            //Mock
            Survey survey = new Survey();
            survey.Name = "Teste";
            survey.Email = "testemeuspedidos@outlook.com";

            //Arrange
            MessageSender messageService = new MessageSender();            
            var controller = new SurveyController(messageService);

            //Act
            ViewResult result = controller.Save(survey) as ViewResult;

            //Assert
            Assert.Equal("Sucess", result.ViewName);      
        }
    }
}