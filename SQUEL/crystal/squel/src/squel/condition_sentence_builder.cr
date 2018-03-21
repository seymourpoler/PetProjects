module SQUEL
    class ConditionSentenceBuilder
        @sentenceResult : String
        @conditional_before : String

        AND = " AND "
        OR = " OR "

        def initialize
            @sentenceResult = ""
            @conditional_before = ""
        end
        
        def and(condition : String)
            if @sentenceResult.empty? || @conditional_before.empty?
                @sentenceResult = condition
            else
                @sentenceResult = @sentenceResult + AND  + condition
            end
            @conditional_before = AND
            return self
        end

        def or(condition : String)
            if @conditional_before.empty?
                @sentenceResult = @sentenceResult + condition                
            else
                @sentenceResult = @sentenceResult + OR  + condition
            end
            
            @conditional_before = OR
            return self
        end

        def or_begin()
            if @conditional_before == AND
                @sentenceResult = @sentenceResult + AND + "("
            else
                @sentenceResult = @sentenceResult + OR + "("
            end
            @conditional_before = ""
            return self
        end

        def end()
            @sentenceResult = @sentenceResult + ")"
        end

        def to_string : String
            return @sentenceResult
        end
    end
end