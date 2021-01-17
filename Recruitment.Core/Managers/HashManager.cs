using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using Recruitment.Core.Interfaces;
using Recruitment.Core.Interfaces.Manager;
using Recruitment.Core.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Managers
{
    public class HashManager : IHashManager
    {
        private IRequestValidation _requestValidation;
        private IFunctionService _funcService;

        public HashManager(IRequestValidation requestValidation,
            IFunctionService funcService)
        {
            _requestValidation = requestValidation;
            _funcService = funcService;
        }

        public async Task<HashResponseModel> HashAsync(HashRequestModel model)
        {
            var success = _requestValidation.ValidateLoginRequest(model, out string message);

            
            if(success)
            {
                var response = await _funcService.Hash(model);

                return response;
            }
            else
            {
                throw new Exception($"Invalid request: {message}");
            }

        }
    }
}
