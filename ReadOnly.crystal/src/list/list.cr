require "./commands/add_at.cr"
require "./commands/equals.cr"
require "./commands/take.cr"
require "./commands/remove_at.cr"
require "./commands/sum.cr"
require "./commands/skip.cr"
require "./commands/get_range.cr"
require "./commands/index_of.cr"
require "./commands/zip.cr"

module ReadOnly
  class List(T)

    NOELEMENTS = 0
    FIRSTPOSITION = 0
    NOPOSITION = -1
    
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
      return ReadOnly::ListCommands::AddAt.new(@elements, position, value).execute
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
      return ReadOnly::ListCommands::Equals.new(@elements, list).execute
    end

    def sum : Int32
      return ReadOnly::ListCommands::Sum.new(@elements).execute
    end

    def take(numberOfElements : Int32) : self
      return ReadOnly::ListCommands::Take.new(@elements, numberOfElements).execute
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
      return ReadOnly::List.new(@elements.reverse)
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
      return ReadOnly::ListCommands::RemoveAt.new(@elements, position).execute
    end

    def clear : self
      return ReadOnly::List(T).new
    end

    def elementAt(position : Int32)
      if position < NOELEMENTS || 
        position >= self.count
        raise IndexError.new
      end
      return @elements[position]
    end

    def first : T
      return @elements.first()
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

    #TODO: extract method
    def last(&condition : T -> Bool)
      if self.empty?
        return nil
      end

      position = self.count - 1
      while position >= 0
        if condition.call(@elements[position])
          return @elements[position]
        end
        position = position - 1
      end
      return nil
    end

    def order_by_ascending
      return ReadOnly::List.new(@elements.sort)
    end

    def order_by_descending
      return ReadOnly::List.new(@elements.sort.reverse)
    end

    def order_by(&condition : T -> _)
      ordered_values = @elements.sort_by &condition
      return ReadOnly::List.new(ordered_values)
    end

    #TODO: refactor condition
    def skip(numberOfElementsForSkipping : Int32) : self
      return ReadOnly::ListCommands::Skip.new(@elements, numberOfElementsForSkipping).execute
    end

    def get_range(position : Int32, length : Int32) : self
      return ReadOnly::ListCommands::GetRange.new(@elements, position, length).execute
    end

    def index_of(value : T) : Int32
      return ReadOnly::ListCommands::IndexOf.new(@elements, value).execute
    end

    def zip(list : List(T)) : self
      return ReadOnly::ListCommands::Zip.new(ReadOnly::List.new(@elements), list).execute
    end

  end
end
