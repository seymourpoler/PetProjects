using System;
using Squel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squel.Test
{
    [TestClass]
    public partial class SquelTest
    {
        [TestMethod]
        public void Should_Return_Simple_Select_One_Field_From_One_Table()
        {
            var expected = "SELECT field FROM Table";
            var sql = new SQL();
            sql.Select("field").From("Table");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Asteric_From_One_Table()
        {
            var expected = "SELECT * FROM Table";
            var sql = new SQL();
            sql.Select().From("Table");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Two_Fields_From_One_Table()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_One_Fields_From_One_Table_With_Acronimus()
        {
            var expected = "SELECT FieldOne FROM Table t";
            var sql = new SQL();
            sql.Select("FieldOne").From("Table", "t");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_More_Than_Two_Fields_From_One_Table()
        {
            var expected = "SELECT FieldOne, FieldTwo, FieldThree, FieldFour, FieldFive FROM Table";
            var sql = new SQL();
            sql.Select()
                .Field("FieldOne").Field("FieldTwo").Field("FieldThree").Field("FieldFour").Field("FieldFive")
                .From("Table");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Limit()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table LIMIT 1";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").Limit(1);

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_OrderBy()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table ORDER BY FieldOne";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").OrderBy("FieldOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_OrderBy_ASC()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table ORDER BY FieldOne ASC";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").OrderBy("FieldOne").Asc();

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_OrderBy_DESC()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table ORDER BY FieldOne DESC";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").OrderBy("FieldOne").Desc();

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Multiple_OrderBy()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table ORDER BY FieldOne DESC, FieldTwo ASC";
            var sql = new SQL();
            sql
                .Select().Field("FieldOne").Field("FieldTwo")
                .From("Table")
                .OrderBy("FieldOne").Desc()
                .OrderBy("FieldTwo").Asc();

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_GroupBy()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table GROUP BY FieldOne";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").GroupBy("FieldOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Where_Condition()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table WHERE FieldOne=valueOne";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").Where("FieldOne=valueOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Where_OrderBy_Limit_Condition()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table WHERE FieldOne=valueOne ORDER BY FieldOne DESC, FieldTwo ASC LIMIT 2";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo")
                .From("Table")
                .Where("FieldOne=valueOne")
                .OrderBy("FieldOne").Desc()
                .OrderBy("FieldTwo").Asc()
                .Limit(2);

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
