module ReadOnly
    module ListCommands
        class Equals(T)

            @other : Array(T)
            @another : List(T)

            def initialize(other : Array(T), another : List(T))
                @other = other
                @another = another 
            end

            def execute : Bool
                if @other.size != @another.count
                    return false
                end
            
                position = 0
                result = true
                @another.each do |element|
                    if @other[position] != element
                    result = false
                    end
                    position = position + 1
                end
                return result && true
            end
        end
    end
end