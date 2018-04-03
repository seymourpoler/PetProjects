module ReadOnly
  class List(T)
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
      return @elements.size == 0
    end

    def sum : Int32
      result = 0
      @elements.each do |element|
          result = result + element
      end
      return result
    end

  end
end
