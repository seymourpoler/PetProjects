module ReadOnly
    module ListCommands
        class Take(T)

            NO_ELEMENTS = 0
            
            @elements : Array(T)
            @numberOfElementsForTaking : Int32

            def initialize(elements : Array(T), numberOfElementsForTaking : Int32)
                @elements = elements
                @numberOfElementsForTaking = numberOfElementsForTaking    
            end

            def execute : List(T)
                if @elements.empty? ||
                   @numberOfElementsForTaking == NO_ELEMENTS
                    return ReadOnly::List.new(@elements)
                end
            
                result = [] of T
                @elements.each do |element|
                if @numberOfElementsForTaking > NO_ELEMENTS
                    result << element
                end
                @numberOfElementsForTaking = @numberOfElementsForTaking - 1
                end
                return ReadOnly::List.new(result)
            end
        end
    end
end