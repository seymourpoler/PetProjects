module SQUEL
    class LimitBuilder
        def build(limit : Int32) : String
            if limit == 0
                return ""
            end
            return " LIMIT " + limit.to_s
        end
    end
    
end