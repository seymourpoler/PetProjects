module SQUEL
    class Select
        @table : String
        @acronimus : String 
        @fields: Array(String)

        def initialize
            @table = ""
            @acronimus = ""
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

        def from(table : String, acronimus : String)
            @table = table
            @acronimus = acronimus
            return self
        end

        def to_string
            return "SELECT " + build_sql_fields() + " FROM " + build_sql_table()
        end

        private def build_sql_fields
            if(@fields.empty?)
                return "*"
            end
            return join(@fields)
        end

        private def join(fields : Array(String))
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

        private def build_sql_table
            if @acronimus == ""
                return @table
            end
            return @table + " " + @acronimus
        end
    end
end