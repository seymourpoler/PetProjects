require "minitest/autorun"

require "../../src/squel/condition_sentence_builder.cr"

class ConditionSentenceBuilderTest < Minitest::Test
    
    def test_expression_with_and
        builder = SQUEL::ConditionSentenceBuilder.new

        assert_equal "id = 'aqswde' AND age > 24", builder.and("id = 'aqswde'").and("age > 24").to_string
    end
end