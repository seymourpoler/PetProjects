module SQUEL
    class Select
        @table : String
        @acronimus : String 
        @fields: Array(String)
        @limit : Int32
        @fieldsBuilder : FieldsBuilder
        @tableBuilder : TableBuilder
        @limitBuilder : LimitBuilder
        @offset : Int32

        def initialize
            @table = ""
            @acronimus = ""
            @fields = [] of String
            @limit = 0
            @fieldsBuilder = FieldsBuilder.new
            @tableBuilder = TableBuilder.new
            @limitBuilder = LimitBuilder.new
            @offset = 0
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

        def offset(offset : Int32)  
            @offset = offset
            return self
        end

        def to_string : String
            return "SELECT " + build_fields() + " FROM " + build_table() + build_limit() + build_offset()
        end

        private def build_fields : String
            return @fieldsBuilder.build(@fields)
        end

        private def build_table : String
            return @tableBuilder.build(@table, @acronimus)
        end

        private def build_limit : String
            return @limitBuilder.build(@limit)
        end

        private def build_offset : String
            if @offset == 0
                return ""
            end
            return " OFFSET " + @offset.to_s
        end
    end
end