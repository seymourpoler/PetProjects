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

    def add(list : List(T))
      list.each do |element|
        @elements << element
      end

      return List.new(@elements)
    end

    def addAt(position : Int32, value : T)
      if self.empty?
        return self
      end
      if position < FIRSTPOSITION
        return self
      end
      if position > self.count
        return self
      end
      if position == self.count
        return self.add(value)
      end
      index = 0      
      values = [] of T
      while index < self.count
        if position == index
          values << value
        end
        values << @elements[index]
        index = index + 1
      end
      return ReadOnly::List.new(values)
    end

    def each(&block : T ->)
      @elements.each do |element|
        block.call element
      end
    end
  
    def count : Int32
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
        if element.is_a? Int32
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

    def where(&condition : T -> Bool) : self
      values = [] of T
      position = 0
      while position < self.count
        if condition.call(@elements[position])
          values << @elements[position]
        end  
        position = position + 1
      end
      return ReadOnly::List(Int32).new(values)
    end

    def reverse : self
      if self.empty?
        return self
      end
      values = [] of T
      position = self.count - 1
      while position >= NOELEMENTS
        values << @elements[position]
        position = position -1
      end
      return ReadOnly::List.new(values)
    end

    def select(&block : T -> U) forall U
      values = @elements.map{|x| block.call(x)}
      return ReadOnly::List(U).new(values)
    end

    def remove(&condition : T -> Bool) : self
      values = [] of T
      position = 0
      while position < self.count
        if condition.call(@elements[position])
          values << @elements[position]  
        end
        position = position + 1
      end
      return ReadOnly::List(T).new(values)
    end

    def removeAt(position : Int32) : self
      if position < NOELEMENTS || position >= self.count
        return self
      end
      
      values = [] of T
      index = 0
      while index < self.count
        if index != position
          values << @elements[index]  
        end
        index = index + 1
      end
      
      return ReadOnly::List(T).new(values)
    end

    def clear : self
      return ReadOnly::List(T).new
    end

    def elementAt(position : Int32)
      if position < NOELEMENTS || position >= self.count
        raise IndexError.new
      end
      return @elements[position]
    end

    #TODO: extract method
    def first(&condition : T -> Bool)
      if self.empty?
        return nil
      end
      result = nil
      first? = true
      @elements.each do |element|
        if condition.call(element) && first?
          result = element
          first? = false
        end
      end
      return result
    end

  end
end
