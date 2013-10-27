using System;
using System.Text;

namespace Squel
{
    public class ConditionSentence: IQuery
    {
        private const string AND = " AND ";
        private const string OR = " OR ";
        private const string BRACKET_OPEN = "(";
        private const string BRACKET_CLOSE = ")";

        private StringBuilder _result;
        private bool _beginOpen;
        private string _operationBefore;

        public ConditionSentence()
        {
            _result = new StringBuilder();
            _beginOpen = false;
            _operationBefore = string.Empty;
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

        public ConditionSentence AndBegin()
        {
            return BuildConditionBegin(AND);
        }

        public ConditionSentence OrBegin()
        {
            if (_operationBefore.Contains(AND))
            {
               return BuildConditionBegin(AND);
            }
            return BuildConditionBegin(OR);
        }

        public ConditionSentence BuildConditionBegin(string condition)
        {
            _beginOpen = true;
            AppendSentence(condition, BRACKET_OPEN);
            return this;
        }

        public ConditionSentence End()
        {
            _result.Append(BRACKET_CLOSE);
            return this;
        }

        private string BuildSentence(string condition, string sentence)
        {
            if (Functions.IsStringEmpty(_result.ToString()) && (!Functions.IsStringEmpty(sentence)))
            {
                _result.Append(sentence);
            }
            else if (_beginOpen == true)
            {
                _beginOpen = false;
                _result.Append(sentence);
            }
            else
            {
                AppendSentence(condition, sentence);
            }

            _operationBefore = condition;
            return _result.ToString();
        }

        private void AppendSentence(string condition, string sentence)
        {
            var conditionAddSentence = string.Format("{0}{1}", condition, sentence);
            _result.Append(conditionAddSentence);
        }

        public string ToSQLString()
        {
            return _result.ToString(); ;
        }
    }
}
