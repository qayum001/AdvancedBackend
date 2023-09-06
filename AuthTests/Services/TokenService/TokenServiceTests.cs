using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auth.Services.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Auth.Services.TokenService.Tests
{
    [TestClass]
    public class TokenServiceTests
    {
        [TestMethod]
        public async void GetUserIdByTokenTest()//fail
        {
            var token = "fewefw";

            var tokenService = new TokenService();

            var res = await tokenService.GetUserIdByToken(token);

            Debug.WriteLine(res + "0000000000000000000000000000000");
            Assert.IsNotNull(res);
        }
    }
}