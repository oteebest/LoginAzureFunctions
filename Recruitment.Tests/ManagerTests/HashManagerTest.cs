﻿using Moq;
using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Exceptions;
using Recruitment.Core.Interfaces;
using Recruitment.Core.Interfaces.Manager;
using Recruitment.Core.Interfaces.Validation;
using Recruitment.Core.Managers;
using Recruitment.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recruitment.Tests.ManagerTests
{
    public class HashManagerTest
    {
        private readonly Mock<IRequestValidation> _reqValidation;
        private readonly Mock<IFunctionService> _funcService;
        private readonly HashManager _hashManager;
        private HashResponseModel responseModel = new HashResponseModel { hash_value = "7287237c19bdb8c59d1869ea9174c713" };

        public HashManagerTest()
        {
            _reqValidation = new Mock<IRequestValidation>(MockBehavior.Strict);
            _funcService = new Mock<IFunctionService>(MockBehavior.Strict);

            _hashManager = new HashManager(_reqValidation.Object, _funcService.Object);

        }

        [ClassData(typeof(HashRequestData))]
        [Theory]
        public async Task ShouldHashRequest(HashRequestModel requestModel)
        {
            //arrange
            string validationMessage = "Validation Successful";

            _reqValidation.Setup(u => u.ValidateLoginRequest(requestModel, out validationMessage))
                .Returns(true);

            _funcService.Setup(u => u.Hash(It.IsAny<HashRequestModel>()))
                .Returns(() => Task.FromResult(responseModel));

            //act
            var response = await _hashManager.HashAsync(requestModel);

            //assert
            _reqValidation.Verify(u => u.ValidateLoginRequest(It.IsAny<HashRequestModel>(), out validationMessage), Times.Once);

            _funcService.Verify(u => u.Hash(It.IsAny<HashRequestModel>()), Times.Once);

            Assert.NotNull(response);

            Assert.NotNull(response.hash_value);


        }
       
        [Fact]
        public async Task ShouldThrowProcessException()
        {
            //arrange
            string validationMessage = "Provide Login";

            HashRequestModel requestModel = new HashRequestModel { Login = "", Password = "Otee" };

            _reqValidation.Setup(u => u.ValidateLoginRequest(requestModel, out validationMessage))
                .Returns(false);

            _funcService.Setup(u => u.Hash(It.IsAny<HashRequestModel>()))
                .Returns(() => Task.FromResult(responseModel));

            //act
         
            await Assert.ThrowsAsync<ProcessException>(() =>  _hashManager.HashAsync(requestModel));

            //assert
            _reqValidation.Verify(u => u.ValidateLoginRequest(It.IsAny<HashRequestModel>(), out validationMessage), Times.Once);

            _funcService.Verify(u => u.Hash(It.IsAny<HashRequestModel>()), Times.Never);



        }
    }
}
