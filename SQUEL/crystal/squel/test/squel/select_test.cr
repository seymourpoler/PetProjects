require "minitest/autorun"

require "../../src/squel/select.cr"
require "../../src/squel/fields_builder.cr"
require "../../src/squel/table_builder.cr"

class SelectTest < Minitest::Test
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

    def test_select_fields_from_table_with_acronimus
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id, name FROM students s", sqlSelect.field("id").field("name").from("students", "s").to_string
    end

    def test_select_fields_from_table_with_acronimus_with_limit
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id, name FROM students s LIMIT 2", sqlSelect.field("id").field("name").from("students", "s").limit(2).to_string
    end
end