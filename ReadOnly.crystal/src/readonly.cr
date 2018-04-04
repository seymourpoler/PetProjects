module ReadOnly
  class List(T)
    NOELEMENTS = 0
    FIRSTPOSITION = 0
    
    @elements : Array(T)

    def initialize
      @elements = [] of T
    end

    def initialize(elements : Array(T))
      @elements = [] of T
      elements.each do |element|
        @elements << element
      end
    end

    def add(element : T) : self
      @elements << element
      return List.new(@elements)
    end

    def addAt(position : Int32, value : T)
      if(self.empty?)
        return self
      end
      if(position < FIRSTPOSITION)
        return self
      end
      if position > self.count
        return self
      end
      raise Exception.new("Not Implemented")
    end


    def each(&block : T ->)
      @elements.each do |element|
        block.call(element)
      end
    end

    def add(list : List(T))
      list.each do |element|
        @elements << element
      end

      return List.new(@elements)
    end
  
    def count() : Int32
      return @elements.size
    end

    def empty? : Bool
      return @elements.size == NOELEMENTS
    end

    def equal?(list : List(T)) : Bool
      if self.count != list.count
        return false
      end
      position = 0
      result = true
      list.each do |element|
        if @elements[position] != element
          result = false
        end
        position = position + 1
      end
      return result && true
    end

    def sum : Int32
      result = 0
      @elements.each do |element|
        if element.is_a?(Int32)
          result = result + element
        end
      end
      return result
    end

    def take(numberOfElements : Int32) : self
      if self.empty?
        return self
      end
      result = [] of T
      @elements.each do |element|
        if numberOfElements > NOELEMENTS
          result << element
        end
        numberOfElements = numberOfElements - 1
      end
      return ReadOnly::List.new(result)
    end

  end
end
