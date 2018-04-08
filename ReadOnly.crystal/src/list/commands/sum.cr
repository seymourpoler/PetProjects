module ReadOnly
    module ListCommands
        class Sum(T)

            @elements : Array(T)

            def initialize(elements : Array(T))
                @elements = elements
            end

            def execute : Int32
                result = 0
                @elements.each do |element|
                    if element.is_a? Int32
                    result = result + element
                    end
                end
                return result
            end
        end
    end
end