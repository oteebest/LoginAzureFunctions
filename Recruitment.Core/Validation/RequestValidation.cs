using Recruitment.Contracts.RequestModel;
using Recruitment.Core.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.Validation
{
    public class RequestValidation : IRequestValidation
    {
        public bool ValidateLoginRequest(HashRequestModel model, out string message)
        {
            bool success = false;

            if(string.IsNullOrEmpty(model.Login) )
            {
                message = "Provide log";
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                message = "Provide password";
            }
            else
            {
                message = "Validation successful";
                success = true;
            }

            return success;

        }
    }
}
