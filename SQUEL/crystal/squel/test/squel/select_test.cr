require "minitest/autorun"

require "../../src/squel/select.cr"

class SelectTest < Minitest::Test
    #def sqlSelect
    #    @sqlSelect ||= SQUEL::Select.new
    #end

    def test_select_all_from_table
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT * FROM students", sqlSelect.from("students").to_string
    end

    def test_select_one_field_from_table
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id FROM students", sqlSelect.field("id").from("students").to_string
    end

    def test_select_fields_from_table
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id, name FROM students", sqlSelect.field("id").field("name").from("students").to_string
    end
end