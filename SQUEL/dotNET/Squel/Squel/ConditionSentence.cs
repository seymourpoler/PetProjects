using System;
using System.Text;

namespace Squel
{
    public class ConditionSentence: IQuery
    {
        private const string AND = " AND ";
        private const string OR = " OR ";

        private StringBuilder _result;

        public ConditionSentence()
        {
            _result = new StringBuilder();
        }

        public ConditionSentence And(string sentence)
        {
            BuildSentence(AND, sentence);
            return this;
        }

        public ConditionSentence Or(string sentence)
        {
            BuildSentence(OR, sentence);
            return this;
        }

        private string BuildSentence(string condition, string sentence)
        {
            if (Functions.IsStringEmpty(_result.ToString()))
            {
                if (!Functions.IsStringEmpty(sentence))
                _result.Append(sentence);
            }
            else
            {
                var conditionAddSentence = string.Format("{0}{1}", condition, sentence);
                _result.Append(conditionAddSentence);
            }
            return _result.ToString();
        }

        public string ToSQLString()
        {
            return _result.ToString(); ;
        }
    }
}
