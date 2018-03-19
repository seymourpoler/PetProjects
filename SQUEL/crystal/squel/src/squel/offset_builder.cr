module SQUEL
    class OffsetBuilder
        def build(offset : Int32) : String
            if offset == 0
                return ""
            end
            return " OFFSET " + offset.to_s
        end
    end
end