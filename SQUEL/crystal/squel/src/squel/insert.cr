module SQUEL
    class Insert
        @table : String
        @fields : Array(String)
        @values : Array(String)

        def initialize
            @table = ""
            @fields  = [] of String
            @values = [] of String
        end

        def into(table : String)
            @table = table
            return self
        end

        def set(field : String, value : String)
            @fields << field
            @values << value
            return self
        end

        def set(field : String, value : Int)
            @fields << field
            @values << value.to_s
            return self
        end

        def set(field : String, value : Float)
            @fields << field
            @values << value.to_s
            return self
        end

        def set(field : String, value : Bool)
            @fields << field
            @values << value.to_s
            return self
        end

        def set(field : String, value : Object)
            @fields << field
            if value.nilable?
                @values << "NULL"
            else
                @values << value.to_s
            end
            return self
        end

        def to_string
            return "INSERT INTO " + @table + " (" + StringUtil.join(@fields, ", ") + ") VALUES (" + StringUtil.join(@values, ", ") + ")"
        end
    end
end