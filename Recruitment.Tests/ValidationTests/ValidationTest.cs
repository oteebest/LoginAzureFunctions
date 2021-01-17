using Moq;
using Recruitment.Contracts.RequestModel;
using Recruitment.Core.Interfaces.Validation;
using Recruitment.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recruitment.Tests.ValidationTests
{
    public class ValidationTest
    {
        private RequestValidation _requestValidation;
        public ValidationTest()
        {
            _requestValidation = new RequestValidation();
        }


        [Fact]
        public async Task ShouldPassRequestValidation()
        {
            //arrange
            HashRequestModel model = new HashRequestModel
            {
                Login = "otee",
                Password = "oteebest"
            };

            //act
            var success = _requestValidation.ValidateLoginRequest(model,out string message );

            //assert
            Assert.True(success,message);
        }

        [Fact]
        public void ShouldFailRequestValidationWhenLoginIsNotProvided()
        {
            //arrange
            HashRequestModel model = new HashRequestModel
            {
                Login = "",
                Password = "oteebest"
            };

            //act
            var success = _requestValidation.ValidateLoginRequest(model, out string message);

            //asset
            Assert.False(success, message);


        }

        [Fact]
        public void ShouldFailRequestValidationWhenPasswordIsNotProvided()
        {
            //arrange
            HashRequestModel model = new HashRequestModel
            {
                Login = "otee",
                Password = ""
            };

            //act
            var success = _requestValidation.ValidateLoginRequest(model, out string message);

            //assert
            Assert.False(success, message);


        }
    }
}
