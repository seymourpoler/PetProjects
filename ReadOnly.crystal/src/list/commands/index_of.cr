module ReadOnly
    module ListCommands
        class IndexOf(T)

            NO_POSITION = -1

            @elements : Array(T)
            @value : T

            def initialize(elements : Array(T), value : T)
                @elements = elements
                @value = value
            end

            def execute
                if @elements.empty?
                    return NO_POSITION
                  end
                  position = 0
                  while position < @elements.size
                    if @elements[position] == @value
                      return position
                    end
                    position = position + 1
                  end
                  return NO_POSITION
            end
        end
        
    end
end