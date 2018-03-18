require "minitest/autorun"

require "../../src/squel/select.cr"

class SelectTest < Minitest::Test
    def sqlSelect
        @sqlSelect ||= SQUEL::Select.new
    end

    def test_select_all_from_table
        assert_equal "SELECT * FROM students", sqlSelect.from("students").to_string
    end
end