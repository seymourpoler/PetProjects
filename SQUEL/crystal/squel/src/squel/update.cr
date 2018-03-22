module SQUEL
    class Update
        @sets : Array(String)
        @table : String

        def initialize
            @sets = [] of String
            @table = ""
        end

        def table(table : String)
            @table = table
            return self
        end

        def set(field : String, value : String)
            @sets << field + " = " + value
            return self
        end

        def set(field : String, value : Int)
            @sets << field + " = " + value.to_s
            return self
        end

        def set(field : String, value : Float)
            @sets << field + " = " + value.to_s
            return self
        end

        def set(field : String, value : Bool)
            @sets << field + " = " + value.to_s
            return self
        end

        def to_string
            return "UPDATE " + @table + " SET " + StringUtil.join(@sets, ", ")
        end
    end
end