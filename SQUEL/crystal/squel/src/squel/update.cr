module SQUEL
    class Update
        @sets : Array(String)
        @table : String
        @conditions : Array(String)

        def initialize
            @sets = [] of String
            @table = ""
            @conditions = [] of String
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
            @conditions << "(" + condition + ")"
            return self
        end

        def to_string
            return "UPDATE " + @table + " SET " + StringUtil.join(@sets, ", ") + build_conditions
        end

        private def build_conditions
            if @conditions.empty?
                return ""
            end
            return  " WHERE " + StringUtil.join(@conditions, " AND ")
        end
    end
end