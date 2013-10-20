using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squel.Test
{
    [TestClass]
    public class SquelDeleteTest
    {
        [TestMethod]
        public void Should_Return_Simple_Delete_From_Table()
        {
            var expected = "DELETE FROM table";
            var sql = new SQL();
            sql.Delete().From("table");

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
