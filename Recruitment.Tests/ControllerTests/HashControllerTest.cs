using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Recruitment.API.Controllers;
using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recruitment.Tests.ControllerTests
{
    public class HashControllerTest
    {
        private readonly Mock<IHashManager> _hashManager;

        private readonly HashController _hashController;
        public HashControllerTest()
        {
            _hashManager = new Mock<IHashManager>(MockBehavior.Strict);

            _hashController = new HashController(_hashManager.Object);

        }

        [Fact]
        public async Task ShouldReturnHasValue()
        {
            //arrange
            _hashManager.Setup(u => u.HashAsync(It.IsAny<HashRequestModel>()))
                .Returns(() => Task.FromResult(new HashResponseModel
                {
                     hash_value = "D4B767CBA7637E855F5278ACC53D434D",
                }));

            HashRequestModel model = new HashRequestModel { Login = "otee", Password = "Oteebest" };

            //act
            var response = await _hashController.Hash(model);

            //assert
            var result = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200,result.StatusCode);

            Assert.IsType<HashResponseModel>(result.Value);

            Assert.Equal("D4B767CBA7637E855F5278ACC53D434D", (( HashResponseModel) result.Value).hash_value );

           

        }
    }
}
