module SQUEL
    class OrderBuilder
        def build(order_by_fields : Array(String)) : String
            #TODO : refactor: extract funcitonality
            if order_by_fields.empty?
                return ""
            end
            result = ""
            order_by_fields.each do |field|
                result = result + field
            end
            return result
        end
    end
end