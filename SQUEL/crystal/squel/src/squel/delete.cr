module SQUEL
    class Delete
        @table : String

        def initialize
            @table = ""
        end

        def from(table : String)
            @table = table
            return self
        end

        def to_string
            return "DELETE FROM " + @table
        end
    end
    
end