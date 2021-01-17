using Newtonsoft.Json;
using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly HttpClient _httpClient;

        public FunctionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HashResponseModel> Hash(HashRequestModel model)
        {
            var requestString = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");

            var result = await  _httpClient.PostAsync("api/hash", httpContent);

            var response = JsonConvert.DeserializeObject<HashResponseModel>( await result.Content.ReadAsStringAsync());

            return response;

        }
    }
}
