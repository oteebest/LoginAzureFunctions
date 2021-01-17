using Recruitment.Contracts.RequestModel;
using Recruitment.Contracts.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Interfaces.Manager
{
    public interface IHashManager
    {
        Task<HashResponseModel> HashAsync(HashRequestModel model);
    }
}
