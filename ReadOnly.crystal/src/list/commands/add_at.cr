module ReadOnly
    module ListCommands
        class AddAt(T)
            FIRST_POSITION = 0
            NO_ELEMENTS = 0
            @elements : Array(T)
            @position : Int32
            @value : T

            def initialize(elements : Array(T), position : Int32, value : T)
                @elements = elements
                @position = position
                @value = value
            end

            def execute
                if @elements.size == NO_ELEMENTS
                    return ReadOnly::List.new(@elements)
                end
                if @position < FIRST_POSITION
                    return ReadOnly::List.new(@elements)
                end
                if @position > @elements.size
                    return ReadOnly::List.new(@elements)
                end
                if @position == @elements.size
                    values = @elements
                    values << @value
                    return ReadOnly::List.new(values)
                end
                index = 0      
                values = [] of T
                while index < @elements.size
                    if @position == index
                        values << @value
                    end
                    values << @elements[index]
                    index = index + 1
                end
                return ReadOnly::List.new(values)
            end
        end
    end
end