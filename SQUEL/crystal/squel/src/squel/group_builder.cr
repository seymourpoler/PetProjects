module SQUEL
    class GroupBuilder
        def build(field : String) : String
            if field.empty?
                return ""
            end
            return " GROUP BY " + field
        end
    end
end