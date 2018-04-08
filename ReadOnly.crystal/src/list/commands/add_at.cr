module ReadOnly
    module ListCommands
        class AddAt(T)
            FIRST_POSITION = 0

            @elements : Array(T)
            @position : Int32
            @value : T

            def initialize(elements : Array(T), position : Int32, value : T)
                @elements = elements
                @position = position
                @value = value
            end

            def execute
                if @elements.empty?
                    return ReadOnly::List.new(@elements)
                end
                if @position < FIRST_POSITION
                    return ReadOnly::List.new(@elements)
                end
                if @position > @elements.size
                    return ReadOnly::List.new(@elements)
                end
                if @position == @elements.size
                    return add_at_the_end(@elements, @value)
                end
                return add_value_at_position(@elements, @position, @value)
            end

            def add_at_the_end(elements : Array(T), value : T)
                values = @elements
                values << @value
                return ReadOnly::List.new(values)
            end

            def add_value_at_position(@elements : Array(T), @position : Int32, @value : T)
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