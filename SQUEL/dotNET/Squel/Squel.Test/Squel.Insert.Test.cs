using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squel.Test
{
    [TestClass]
    public class SquelInsertTest
    {

        [TestMethod]
        public void Should_Return_Insert_In_One_Table()
        {
            var expected = "INSERT INTO students (name) VALUES (Thomas)";

            var sql = new SQL();
            sql.Insert()
                .Into("students")
                .Set("name", "Thomas");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Insert_With_Some_Sets_From_One_Table()
        {
            var expected = "INSERT INTO students (name, age, score, graduate, nickname) VALUES (Thomas, 29, 90.2, True, NULL)";

            var sql = new SQL();
            sql.Insert()
                .Into("students")
                .Set("name", "Thomas")
                .Set("age", 29)
                .Set("score", 90.2)
                .Set("graduate", true)
                .Set("nickname", null);

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
