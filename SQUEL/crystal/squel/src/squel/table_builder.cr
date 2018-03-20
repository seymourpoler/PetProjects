module SQUEL
    class TableBuilder
        def build(tables : Array(String)) : String
            #TODO : refactor: extract funcitonality
            if tables.empty?
                return ""
            end
            result = ""
            last_table = tables.last   
            tables.each do |table|
                if table == last_table
                    result = result + table
                else
                    result = result +  table + ", "
                end
            end
            return result
        end
    end
end