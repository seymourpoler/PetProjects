module SQUEL
    class OrderBuilder
        def build(field : String, ascending : Bool) : String
            if field == ""
                return ""
            end
            if ascending
                return " ORDER BY " + field + " ASC"
            end
            return " ORDER BY " + field
        end
    end
end