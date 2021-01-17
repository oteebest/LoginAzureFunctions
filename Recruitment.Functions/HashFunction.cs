using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Recruitment.Contracts.RequestModel;
using Recruitment.Core.Util;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Interfaces.Manager;

namespace Recruitment.Functions
{
    public static class HashFunction
    {
       

        [FunctionName("Hash")]
        public static async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
           
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var requestModel = JsonConvert.DeserializeObject<HashRequestModel>(requestBody);

            HashResponseModel response = new HashResponseModel
            {
                hash_value = HashUtility.GetMD5Hash($"{requestModel.Login}{requestModel.Password}")
            };

            return new OkObjectResult(response);


        }
    }
}
