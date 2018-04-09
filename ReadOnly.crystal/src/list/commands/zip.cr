module ReadOnly
    module ListCommands
        class Zip(T)

            @other : List(T)
            @another : List(T)

            def initialize(other : List(T), another : List(T))
                @other = other
                @another = another
            end

            def execute
                return zip_lists(@other, @another)
            end

            def zip_lists(other : List(T), another : List(T))
                if other.empty?
                    return another
                end
                if another.empty?
                    return other
                end
                headOther = other.first
                restOfOther = other.removeAt(0)
                headAnother = another.first
                restOfAnother = another.removeAt(0)
                result = zip_lists(restOfOther, restOfAnother)
                return result
                    .addAt(0, headAnother)
                    .addAt(0, headOther)
            end
        end
    end
end