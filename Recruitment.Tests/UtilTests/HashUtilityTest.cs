using Recruitment.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Recruitment.Tests.UtilTests
{
    public class HashUtilityTest
    {
        public HashUtilityTest()
        {

        }

        [InlineData("Otee")]
        [Theory]
        public void ShouldGetMD5HashOfValue(string text)
        {
            //arrange
            string input = text;

            //act
            var output = HashUtility.GetMD5Hash(input);

            //assert
            Assert.Equal("D4B767CBA7637E855F5278ACC53D434D", output);

        }
    }
}
