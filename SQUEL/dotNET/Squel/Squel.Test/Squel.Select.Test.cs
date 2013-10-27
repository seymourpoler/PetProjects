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
        public void Should_Return_Select_One_Fields_From_One_Table_With_Offset()
        {
            var expected = "SELECT FieldOne FROM Table OFFSET 102";
            var sql = new SQL();
            sql.Select().Field("FieldOne")
                        .From("Table")
                        .Offset(102);

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
                sql.Select().Field("FieldOne")
                            .Field("FieldTwo")
                   .From("Table")
                   .OrderBy("FieldOne").Asc();

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
            sql.Select().Field("FieldOne")
                        .Field("FieldTwo")
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
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").Group("FieldOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Where_Condition()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table WHERE (FieldOne = valueOne)";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo").From("Table").Where("FieldOne = valueOne");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Two_Where_Condition()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table WHERE (FieldOne = valueOne) AND (FieldTwo = ValueTwo)";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo")
                        .From("Table")
                        .Where("FieldOne = valueOne")
                        .Where("FieldTwo = ValueTwo");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_One_Fields_From_One_Table_With_Where_Expresion()
        {
            var expected = "SELECT FieldOne FROM Table WHERE (FieldOne = 'valueOne' OR FieldTwo > ValueTwo)";
            var sql = new SQL();
            var sqlExpresion = new SQL();
            sql.Select().Field("FieldOne")
                        .From("Table")
                        .Where(sqlExpresion.Expr().And("FieldOne = 'valueOne'").Or("FieldTwo > ValueTwo"));

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Three_Fields_From_One_Table_With_Where_Two_OrderBys_Limit_Condition()
        {
            var expected = "SELECT FieldOne, FieldTwo FROM Table WHERE (FieldOne = valueOne) ORDER BY FieldOne DESC, FieldTwo ASC LIMIT 2";
            var sql = new SQL();
            sql.Select().Field("FieldOne").Field("FieldTwo")
                .From("Table")
                .Where("FieldOne = valueOne")
                .OrderBy("FieldOne").Desc()
                .OrderBy("FieldTwo").Asc()
                .Limit(2);

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_From_Two_Tables()
        {
            var expected = "SELECT * FROM students, lecturers l, admins";
            var sql = new SQL();
            sql.Select()
                .From("students")
                .From("lecturers", "l")
                .From("admins");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_Into_Another_Select()
        {
            var expected = "SELECT s.id FROM (SELECT * FROM students) s";
            var sql = new SQL();
            var subSql = new SQL();
            sql.Select()
                .From(
                    subSql.Select()
                          .From("students"), "s"
                    )
                .Field("s.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Simple_Select_With_Alias_In_The_Fields()
        {
            var expected = "SELECT s.id, s.test_score AS 'Test score', DATE_FORMAT(s.date_taken, '%M %Y') AS 'Taken on' FROM students s";
            var sql = new SQL();
            sql.Select()
               .From("students", "s")
               .Field("s.id")
               .Field("s.test_score", "Test score")
               .Field("DATE_FORMAT(s.date_taken, '%M %Y')", "Taken on");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Simple_Select_With_Some_GroupsBy()
        {
            var expected = "SELECT id FROM students GROUP BY id, students.name";
            var sql = new SQL();
            sql.Select()
               .Field("id")
               .From("students")
               .Group("id")
               .Group("students.name");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Simple_Select_With_Distinct()
        {
            var expected = "SELECT DISTINCT id FROM students";
            var sql = new SQL();
            sql.Select()
                .From("students")
                .Field("id")
                .Distinct();

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Inner_Joim()
        {
            var expected = "SELECT * FROM students INNER JOIN teachers";
            var sql = new SQL();
            sql.Select()
             .From("students")
             .Join("teachers");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Outer_Join()
        {
            var expected = "SELECT * FROM students INNER JOIN teachers OUTER JOIN expelled";
            var sql = new SQL();
            sql.Select()
                .From("students")
                .Join("teachers")
                .OuterJoin("expelled");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Outer_Join_With_Alias()
        {
            var expected = "SELECT * FROM students INNER JOIN teachers t OUTER JOIN expelled";
            var sql = new SQL();
            sql.Select()
                .From("students")
                .Join("teachers", "t")
                .OuterJoin("expelled");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers ON (students.id = teachers.student_id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "students.id = teachers.student_id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join_And_Alias()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers t ON (students.id = t.student_id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "t", "students.id = t.student_id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Right_Join()
        {
            var expected = "SELECT students.id FROM students RIGHT JOIN jailed ON (jailed.student_id = students.id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .RightJoin("jailed", "jailed.student_id = students.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join_And_Right_Join()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers ON (students.id = teachers.student_id) RIGHT JOIN jailed ON (jailed.student_id = students.id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "students.id = teachers.student_id")
               .RightJoin("jailed", "jailed.student_id = students.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join_And_Right_Join_Add_Alias()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers ON (students.id = teachers.student_id) RIGHT JOIN jailed j ON (j.student_id = students.id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "students.id = teachers.student_id")
               .RightJoin("jailed", "j", "j.student_id = students.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join_Add_Alias_And_Right_Join()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers t ON (students.id = t.student_id) RIGHT JOIN jailed ON (jailed.student_id = students.id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "t", "students.id = t.student_id")
               .RightJoin("jailed", "jailed.student_id = students.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_Left_Join__Add_Alias_And_Right_Join_Add_Alias()
        {
            var expected = "SELECT students.id FROM students LEFT JOIN teachers t ON (students.id = t.student_id) RIGHT JOIN jailed j ON (j.student_id = students.id)";
            var sql = new SQL();
            sql.Select()
               .Field("students.id")
               .From("students")
               .LeftJoin("teachers", "t", "students.id = t.student_id")
               .RightJoin("jailed", "j", "j.student_id = students.id");

            Assert.AreEqual(expected, sql.ToString());
        }

        [TestMethod]
        public void Should_Return_Select_With_INNER_Join__Add_SQL_Expression()
        {
            var expected = "SELECT s.id FROM students s WHERE (s.name <> 'Fred' AND (s.id = 5 OR s.id = 6)) INNER JOIN teachers t ON (s.id = t.sid AND t.name = 'Frances')";
            var sql = new SQL();
            var sqlExpressionJoin = new SQL();
            var sqlExpressionWhere = new SQL();
            sql.Select().Field("s.id")
               .From("students", "s")
               .Where(
                    sqlExpressionWhere.Expr()
                       .And("s.name <> 'Fred'")
                       .OrBegin()
                         .Or("s.id = 5")
                         .Or("s.id = 6")
                       .End()
                     )
              .Join("teachers", "t",
                 sqlExpressionJoin.Expr()
                     .And("s.id = t.sid")
                     .And("t.name = 'Frances'")
            );

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
