using Recruitment.Contracts.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.Interfaces.Validation
{
    public interface IRequestValidation
    {
        bool ValidateLoginRequest(HashRequestModel model, out string message);
    }
}
