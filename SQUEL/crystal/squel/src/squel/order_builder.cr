module SQUEL
    class OrderBuilder
        def build(field : String, ascending : Bool, descending : Bool) : String
            if field == ""
                return ""
            end
            if ascending
                return " ORDER BY " + field + " ASC"
            end
            if descending
                return " ORDER BY " + field + " DESC"
            end
            return " ORDER BY " + field
        end
    end
end