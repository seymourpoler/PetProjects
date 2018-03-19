module SQUEL
    class TableBuilder
        def build(table : String, acronimus : String) : String
            if acronimus == ""
                return table
            end
            return table + " " + acronimus
        end
    end
end