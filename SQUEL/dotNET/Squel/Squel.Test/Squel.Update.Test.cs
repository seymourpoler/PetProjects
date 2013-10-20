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
        public void Should_Return_Update_On_One_Field_From_One_Table_With_Where()
        {
            var expected = "UPDATE table SET f = ? WHERE FieldOne = ValueOne";

            var sql = new SQL();
            sql.Update().Table("table").Set("f", "?").Where("FieldOne = ValueOne");

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
