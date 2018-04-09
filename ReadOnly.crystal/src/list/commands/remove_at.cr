module ReadOnly
    module ListCommands
        class RemoveAt(T)
            
            NO_ELEMENTS = 0

            @elements : Array(T)
            @position : Int32

            def initialize(elements : Array(T), position : Int32)
                @elements = elements
                @position = position    
            end

            def execute : List(T)
                if @position < NO_ELEMENTS || 
                    @position >= @elements.size
                    return ReadOnly::List(T).new(@elements)
                 end
                 
                 values = [] of T
                 index = 0
                 while index < @elements.size
                   if index != @position
                     values << @elements[index]  
                   end
                   index = index + 1
                 end
                 return ReadOnly::List(T).new(values)
            end
        end
    end
end