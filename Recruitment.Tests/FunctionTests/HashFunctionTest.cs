using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recruitment.Tests.FunctionTests
{
    public class HashFunctionTest
    {
        private readonly Mock<ILogger> _logger;

        private readonly Mock<HttpRequest> _httpRequest;
        public HashFunctionTest()
        {
            _logger = new Mock<ILogger>();

            _httpRequest = new Mock<HttpRequest>();


        }

        [Fact]
        public async Task ShouldHashRequest()
        {

            HashRequestModel model = new HashRequestModel { Login = "Otee", Password = "Oteebest" };


            var json = JsonConvert.SerializeObject(model);

            var byteArray = Encoding.ASCII.GetBytes(json);

            MemoryStream _memoryStream = new MemoryStream(byteArray);
            _memoryStream.Flush();
            _memoryStream.Position = 0;

            _httpRequest.Setup(x => x.Body).Returns(_memoryStream);

            var response =   await HashFunction.Run(_httpRequest.Object, _logger.Object);

            //assert
            var result = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200, result.StatusCode);

            Assert.IsType<HashResponseModel>(result.Value);

            Assert.Equal("DB0E8B62C29CEAB7298679CB28E5D6E8", ((HashResponseModel)result.Value).hash_value);


        }
    }
}
