using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squel.Test
{
    [TestClass]
    public class SquelUpdateTest
    {
        [TestMethod]
        public void Should_Return_Update_On_One_Field_From_One_Table()
        {
            var expected = "UPDATE table SET f = ?";

            var sql = new SQL();
            sql.Update().Table("table").Set("f","?");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Update_With_Some_Set_From_One_Table()
        {
            var expected = "UPDATE students SET name = 'Fred', age = 29, score = 1.2, graduate = False";

            var sql = new SQL();
            sql.Update()
                .Table("students")
                .Set("name", "'Fred'")
                .Set("age", 29)
                .Set("score", 1.2)
                .Set("graduate", false);

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Update_With_Some_Set_From_One_Table_With_NULL()
        {
            var expected = "UPDATE students SET name = 'Fred', age = 29, score = 1.2, nichname = NULL";

            var sql = new SQL();
            sql.Update()
                .Table("students")
                .Set("name", "'Fred'")
                .Set("age", 29)
                .Set("score", 1.2)
                .Set("nichname", null);

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Update_On_One_Field_From_One_Table_With_Where()
        {
            var expected = "UPDATE table SET f = ? WHERE (FieldOne = ValueOne)";

            var sql = new SQL();
            sql.Update().Table("table").Set("f", "?").Where("FieldOne = ValueOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Update_On_One_Field_From_One_Table_With_Two_Where()
        {
            var expected = "UPDATE table SET f = ? WHERE (FieldOne = ValueOne) AND (FieldTwo = ValueTwo)";

            var sql = new SQL();
            sql.Update()
               .Table("table")
               .Set("f", "?")
               .Where("FieldOne = ValueOne")
               .Where("FieldTwo = ValueTwo");

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
