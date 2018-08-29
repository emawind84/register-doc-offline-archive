using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pmis;
using pmis.clss;
using System.Data;
using System.IO;

namespace archiveTest
{
    [TestClass]
    public class ClssServiceTest
    {

        private SQLiteDaoService daoService;

        [TestInitialize]
        public void Setup()
        {
            AppConfig.InitConfig();

            daoService = new SQLiteDaoService(Path.Combine( AppConfig.AppDataFullPath, "data\\junit.db"));
            // open db connection before doing anything else
            daoService.Open();
        }

        [TestMethod]
        public void TestLoadClassificationList()
        {

            ClssService service = new ClssService(daoService);
            DataTable ret = service.LoadClassificationList();
            DisplayTable(ret);
            Assert.IsTrue(ret.Rows.Count > 0);
            
        }

        public void DisplayTable(DataTable table)
        {
            var productNames = from products in table.AsEnumerable() select products.Field<string>("Name");
            foreach (string productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }
    }
}
