module SQUEL
    class Select

        @table : String
        #def table
        #    @table
        #end

        #setter table

        def initialize
            @table = ""    
        end

        def from(table : String)
            @table = table
            return self
        end

        def to_string
            return "SELECT * FROM " + @table
        end
    end
end