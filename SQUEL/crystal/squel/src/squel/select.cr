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
        @offsetBuilder : OffsetBuilder
        @order_by_fields : Array(String)
        @orderBuilder : OrderBuilder
        @group_field : String

        def initialize
            @table = ""
            @acronimus = ""
            @fields = [] of String
            @limit = 0
            @fieldsBuilder = FieldsBuilder.new
            @tableBuilder = TableBuilder.new
            @limitBuilder = LimitBuilder.new
            @offset = 0
            @offsetBuilder = OffsetBuilder.new
            @order_by_fields = [] of String
            @orderBuilder = OrderBuilder.new
            @group_field = ""
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

        def order_by(field : String)
            if @order_by_fields.empty?
                @order_by_fields << " ORDER BY " + field
            else
                @order_by_fields << ", " + field
            end
            return self
        end

        def asc()
            @order_by_fields << " ASC"
            return self
        end

        def desc()
            @order_by_fields << " DESC"
            return self
        end

        def group(field : String)
            @group_field = field
            return self
        end

        def to_string : String
            return "SELECT " + build_fields() + " FROM " + build_table() + build_limit() + build_offset() + build_order_by() + build_group_by()
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
            return @offsetBuilder.build(@offset)
        end

        private def build_order_by : String
            return @orderBuilder.build(@order_by_fields)
        end

        private def build_group_by : String
            if @group_field == ""
                return ""
            end
            return " GROUP BY " + @group_field
        end
    end
end