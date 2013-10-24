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

        [TestMethod]
        public void Should_Return_Simple_Delete_From_Table_With_Some_Where()
        {
            var expected = "DELETE FROM students WHERE (id > 5) AND (id < 102)";
            var sql = new SQL();
            sql.Delete()
                .From("students")
                .Where("id > 5")
                .Where("id < 102");

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
