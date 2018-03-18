module SQUEL
    class Select
        @table : String
        @fields: Array(String)

        def initialize
            @table = ""
            @fields = [] of String
        end

        def field(field : String)
            @fields << field
            return self
        end

        def from(table : String)
            @table = table
            return self
        end

        def to_string
            return "SELECT " + fields() + " FROM " + @table
        end

        private def fields
            if(@fields.empty?)
                return "*"
            end
            return join(@fields)
        end

        private def join(fields : Array(String))
            result = ""
            last_field = fields.last
            fields.each do |field|
                if field = last_field
                    result = result + field
                else
                    result = result + ", " + field
                end
            end
            return result
        end
    end
end