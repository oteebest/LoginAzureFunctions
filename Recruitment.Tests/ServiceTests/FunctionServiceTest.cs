using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Interfaces;
using Recruitment.Core.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Recruitment.Tests.ServiceTests
{

    public class FunctionServiceTest
    {
        public FunctionServiceTest()
        {
           
            
        }

        
        [Fact]
        public async Task ShouldReturnHashedValue()
        {
            //arrange
            HashRequestModel model = new HashRequestModel { Login = "otee", Password = "oteebest" };
            HashResponseModel responseModel = new HashResponseModel {  hash_value = "otee" };

            var handlerMock = new Mock<HttpMessageHandler>();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseModel)),
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(httpResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            httpClient.BaseAddress = new Uri("http://localhost:7071");

            FunctionService service = new FunctionService(httpClient);

           //act
            var serviceResponse =  await service.Hash(model);

            //assert
            Assert.NotNull(service);

            Assert.NotNull(serviceResponse.hash_value);



        }
    }
}
