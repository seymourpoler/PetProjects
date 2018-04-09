module ReadOnly
    module ListCommands
    class Skip(T)

        @elements : Array(T)
        @numberOfElementsForSkipping : Int32

        def initialize(elements : Array(T), numberOfElementsForSkipping : Int32)
            @elements = elements
            @numberOfElementsForSkipping = numberOfElementsForSkipping
        end

        def execute
            if @elements.empty?
                return ReadOnly::List.new(@elements)
              end
              if @elements.size < @numberOfElementsForSkipping
                raise ArgumentError.new
              end
              skipped_values = [] of T
              position = 0
              while position < @elements.size
                if position > @numberOfElementsForSkipping - 1
                  skipped_values << @elements[position]
                end
                position = position + 1
              end
              return ReadOnly::List.new(skipped_values)
        end
    end
    end
end