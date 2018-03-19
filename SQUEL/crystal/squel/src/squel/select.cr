module SQUEL
    class Select
        @table : String
        @acronimus : String 
        @fields: Array(String)
        @limit : Int32
        @fieldsBuilder : FieldsBuilder

        def initialize
            @table = ""
            @acronimus = ""
            @fields = [] of String
            @limit = 0
            @fieldsBuilder = FieldsBuilder.new
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

        def limit(limit : Int32)
            @limit = limit
            return self
        end

        def to_string : String
            return "SELECT " + build_fields() + " FROM " + build_table() + build_limit()
        end

        private def build_fields : String
            return @fieldsBuilder.build(@fields)
        end
        
        private def build_table : String
            if @acronimus == ""
                return @table
            end
            return @table + " " + @acronimus
        end

        private def build_limit : String
            if(@limit == 0)
                return ""
            end
            return " LIMIT " + @limit.to_s
        end
    end
end