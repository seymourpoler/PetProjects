module SQUEL
    class Select
        @tables : Array(String)
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
        @groupBuilder : GroupBuilder
        @where_conditions : Array(String)
        @distinct_selector : Bool
        @inner_join_table : String
        @outer_join_table : String
        @left_join_sentence : String
        @right_join_sentence : String
        @having_sentence : String

        def initialize
            @tables = [] of String
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
            @groupBuilder = GroupBuilder.new
            @where_conditions = [] of String
            @distinct_selector = false
            @inner_join_table = ""
            @outer_join_table = ""
            @left_join_sentence = ""
            @right_join_sentence = ""
            @having_sentence = ""
        end

        def field(field : String)
            @fields << field
            return self
        end

        def field(field : String, acronimus : String)
            @fields << field + " AS " + "'" + acronimus + "'"
            return self
        end

        def distinct()
            @distinct_selector = true
            return self
        end

        def from(table : String)
            @tables << table
            return self
        end

        def from(table : String, acronimus : String)
            @tables << table + " " + acronimus
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

        def where(condition : String)
            @where_conditions << condition
            return self
        end

        def join(table : String)
            @inner_join_table = table
            return self
        end

        def join(table : String, acronimus : String)
            @inner_join_table = table + " " + acronimus
            return self
        end

        def outer_join(table : String)
            @outer_join_table = table
            return self
        end

        def outer_join(table : String, acronimus : String)
            @outer_join_table = table + " " + acronimus
            return self
        end

        def left_join(table : String, condition : String)
            @left_join_sentence = " LEFT JOIN " + table + " ON " + "(" + condition + ")"
            return self
        end

        def left_join(table : String, acronimus : String, condition : String)
            @left_join_sentence = " LEFT JOIN " + table + " " + acronimus +  " ON " + "(" + condition + ")"
            return self
        end

        def right_join(table : String, condition : String)
            @right_join_sentence = " RIGHT JOIN " + table + " ON " + "(" + condition + ")"
            return self
        end

        def right_join(table : String, acronimus : String, condition : String)
            @right_join_sentence = " RIGHT JOIN " + table + " " + acronimus +  " ON " + "(" + condition + ")"
            return self
        end

        def having(sentence : String)
            @having_sentence = " HAVING " + "(" + sentence + ")"
            return self
        end

        def to_string : String
            return "SELECT " + build_distinct() + build_fields() + " FROM " + build_table() + build_limit() + build_offset() + build_order_by() + build_group_by() + build_where_condition() + build_inner_join() + build_outer_join() + @left_join_sentence + @right_join_sentence + @having_sentence
        end

        private def build_fields : String
            return @fieldsBuilder.build(@fields)
        end

        private def build_table : String
            return @tableBuilder.build(@tables)
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
            return @groupBuilder.build(@group_field)
        end

        private def build_where_condition : String
            if @where_conditions.empty?
                return ""
            end
            result = " WHERE "
            last_condition = @where_conditions.last   
            @where_conditions.each do |condition|
                if condition == last_condition
                    result = result + condition
                else
                    result = result +  condition + " AND "
                end
            end
            return result
        end

        private def build_distinct : String
            if @distinct_selector
                return "DISTINCT "
            end
            return ""
        end

        private def build_inner_join : String
            if @inner_join_table.empty?
                return ""
            end
            return " INNER JOIN " + @inner_join_table
        end

        private def build_outer_join : String
            if @outer_join_table.empty?
                return ""
            end
            return " OUTER JOIN " + @outer_join_table
        end
    end
end