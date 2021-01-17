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
            Add(new HashRequestModel { Login = "otee", Password = "oteebest" });
            Add(new HashRequestModel { Login = "otee", Password = "oteebest" });
            Add(new HashRequestModel { Login = "otee", Password = "oteebest" });
            Add(new HashRequestModel { Login = "otee", Password = "oteebest" });
        }

    }




}
