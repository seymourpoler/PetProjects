module SQUEL
    class ConditionSentenceBuilder
        @sentenceResult : String

        def initialize
            @sentenceResult = ""
        end
        
        def and(condition : String)
            if @sentenceResult.empty?
                @sentenceResult = condition
            else
                @sentenceResult = @sentenceResult + " AND "  + condition
            end
            return self
        end

        def or(condition : String)
            raise Exception.new("not implemented")
            return self
        end

        def to_string : String
            return @sentenceResult
        end
    end
end