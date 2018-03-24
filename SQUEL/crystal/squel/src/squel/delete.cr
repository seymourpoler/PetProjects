module SQUEL
    class Delete
        @table : String
        @conditions : Array(String)

        def initialize
            @table = ""
            @conditions = [] of String
        end

        def from(table : String)
            @table = table
            return self
        end

        def where(condition : String)
            @conditions << "(" + condition + ")"
            return self
        end

        def to_string
            return "DELETE FROM " + @table + build_conditions
        end

        private def build_conditions
            if @conditions.empty?
                return ""
            end
            return " WHERE " + StringUtil.join(@conditions, " AND ")
        end
    end
end