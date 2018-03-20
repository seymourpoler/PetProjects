module SQUEL
    class FieldsBuilder
        def build(fields : Array(String)) : String
            if(fields.empty?)
                return "*"
            end
            return StringUtil.join(fields, ", ")
        end
    end
end