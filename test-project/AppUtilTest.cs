using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pmis;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace archiveTest
{
    [TestClass]
    public class AppUtilTest
    {
        [TestMethod]
        public async Task RequestPMISToken()
        {
            IDictionary obj = await AppUtil.RequestPMISToken("https://pmis.sangah.com", "sangah1", "sangah1");
            Assert.IsNotNull(obj["access_token"]);
        }
    }
}
