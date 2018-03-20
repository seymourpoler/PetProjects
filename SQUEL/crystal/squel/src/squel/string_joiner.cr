module SQUEL
    class StringUtil
        def self.join(values : Array(String), separator : String)
            if values.empty?
                return ""
            end
            result = ""
            last_value = values.last   
            values.each do |value|
                if value == last_value
                    result = result + value
                else
                    result = result + value + separator
                end
            end
            return result
        end
    end
end