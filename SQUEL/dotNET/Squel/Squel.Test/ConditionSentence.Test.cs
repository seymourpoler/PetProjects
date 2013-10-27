using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Squel.Test
{
    [TestClass]
    public class ConditionSentence
    {
        [TestMethod]
        public void Should_Return_Complex_Expression()
        {
            var expected = "id < 500 AND (id > 100 OR name <> 'Thomas') AND (age BETWEEN 20 AND 25 OR name <> 'Fred') OR nickname = 'Hardy'";
            var sql = new SQL();
            sql.Expr()
                .And("id < 500")
                .AndBegin()
                    .Or("id > 100")
                    .Or("name <> 'Thomas'")
                .End()
                .AndBegin()
                    .Or("age BETWEEN 20 AND 25")
                    .Or("name <> 'Fred'")
                .End()
                .Or("nickname = 'Hardy'");

            Assert.AreEqual(expected, sql.ToString());
        }
    }
}
