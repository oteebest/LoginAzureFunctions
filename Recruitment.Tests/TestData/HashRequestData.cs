using Recruitment.Contracts.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Recruitment.Tests.TestData
{
    public class HashRequestData : TheoryData<HashRequestModel>
    {
        public HashRequestData()
        {
            Add(new HashRequestModel { Login = "otee", Password = "oteebest" });
            Add(new HashRequestModel { Login = "mena", Password = "Ziregbe" });
            Add(new HashRequestModel { Login = "onome", Password = "Frank" });
            Add(new HashRequestModel { Login = "tobechi", Password = "Okani" });
            Add(new HashRequestModel { Login = "fromo", Password = "Adiaste" });
        }

    }




}
