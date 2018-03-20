using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using QuanLyTrangTrai;

namespace UnitTestTrangTrai
{
    /// <summary>
    /// Summary description for UnitTestTrangTrai
    /// </summary>
    [TestClass]
    public class UnitTestTrangTrai
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("UnitTestT4rangTrtai\\TestData.csv"), TestMethod]
        public void TestMethodThemVatNuoi()
        {
            DataTable tableVN = Database.Instance.LoadTable("select * from VatNuoi");
            DataRow dr = tableVN.NewRow();
            dr[0] = TestContext.DataRow[0].ToString();
            dr[1] = TestContext.DataRow[1].ToString();
            dr[2] = TestContext.DataRow[2].ToString();
            dr[3] = TestContext.DataRow[3].ToString();
            tableVN.Rows.Add(dr);
            Assert.IsTrue(VatNuoi.Instance.SaveTableVatNuoi(tableVN));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("UnitTestT4rangTrtai\\TestData.csv"), TestMethod]
        public void TestMethodSuaVatNuoi()
        {
            DataTable tableVN = Database.Instance.LoadTable("select * from VatNuoi");
            int row = tableVN.Rows.Count - 1;
            tableVN.Rows[row][0] = TestContext.DataRow[0].ToString();
            tableVN.Rows[row][1] = TestContext.DataRow[1].ToString();
            tableVN.Rows[row][2] = TestContext.DataRow[2].ToString();
            tableVN.Rows[row][3] = TestContext.DataRow[3].ToString();
            Assert.IsTrue(VatNuoi.Instance.SaveTableVatNuoi(tableVN));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("UnitTestT4rangTrtai\\TestData.csv"), TestMethod]
        public void TestMethodXoaVatNuoi()
        {
            DataTable tableVN = Database.Instance.LoadTable("select * from VatNuoi");
            int row = tableVN.Rows.Count - 1;
            tableVN.Rows[row].Delete();
            Assert.IsTrue(VatNuoi.Instance.SaveTableVatNuoi(tableVN));
        }
    }
}
