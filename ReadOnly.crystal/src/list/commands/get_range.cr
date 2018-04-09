module ReadOnly
    module ListCommands
        class GetRange(T)

            @elements : Array(T)
            @position : Int32
            @length : Int32

            def initialize(elements : Array(T), position : Int32, length : Int32)
                @elements = elements
                @position = position
                @length = length
            end

            def execute
                if @elements.empty?
                    return ReadOnly::List.new(@elements)
                  end
            
                  if @position > @elements.size
                    raise ArgumentError.new
                  end 
            
                  if @position + @length > @elements.size
                    raise ArgumentError.new
                  end
            
                  index = 0
                  ranged_values = [] of T
                  while index < @elements.size
                    if ( index >= @position ) && ( index < @position + @length)
                      ranged_values << @elements[index]
                    end
                    index = index + 1
                  end
                  return ReadOnly::List.new(ranged_values)
            end
        end
    end
end