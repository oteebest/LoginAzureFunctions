using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Contracts.RequestModel;
using Recruitment.Core.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        private IHashManager _hashManager;
        public HashController(IHashManager hashManager)
        {
            _hashManager = hashManager;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Hash(HashRequestModel model)
        {
            var responseModel = await _hashManager.HashAsync(model);

            return Ok(responseModel);
        }

    }
}
