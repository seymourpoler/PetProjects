module SQUEL
    class TableBuilder
        def build(tables : Array(String)) : String
            return StringUtil.join(tables, ", ")
        end
    end
end