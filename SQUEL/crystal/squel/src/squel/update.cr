module SQUEL
    class Update
        @sets : Array(String)
        @table : String
        @where : String

        def initialize
            @sets = [] of String
            @table = ""
            @where = ""
        end

        def table(table : String)
            @table = table
            return self
        end

        def table(table : String, acronimus : String)
            @table = table + " " + acronimus
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

        def where(condition : String)
            @where = " WHERE " + "(" + condition + ")"
            return self
        end

        def to_string
            return "UPDATE " + @table + " SET " + StringUtil.join(@sets, ", ") + @where
        end
    end
end