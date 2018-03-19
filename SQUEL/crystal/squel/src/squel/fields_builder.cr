module SQUEL
    class FieldsBuilder
        def build(fields : Array(String)) : String
            if(fields.empty?)
                return "*"
            end
            return join(fields)
        end

        private def join(fields : Array(String)) : String
            result = ""
            last_field = fields.last   
            fields.each do |field|
                if field == last_field
                    result = result + field
                else
                    result = result +  field + ", "
                end
            end
            return result
        end
    end
end