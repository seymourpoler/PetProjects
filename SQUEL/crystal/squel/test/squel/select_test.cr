require "minitest/autorun"

require "../../src/squel/select.cr"
require "../../src/squel/fields_builder.cr"
require "../../src/squel/table_builder.cr"
require "../../src/squel/limit_builder.cr"
require "../../src/squel/offset_builder.cr"
require "../../src/squel/order_builder.cr"

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

    def test_select_fields_from_table_with_offset
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id, name FROM students OFFSET 102", sqlSelect.field("id").field("name").from("students").offset(102).to_string
    end

    def test_select_fields_from_table_order_by
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT id, name FROM students ORDER BY age", sqlSelect.field("id").field("name").from("students").order_by("age").to_string
    end

    def test_select_fields_from_table_order_by_ascending
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT name FROM students ORDER BY age ASC", sqlSelect.field("name").from("students").order_by("age").asc().to_string
    end

    def test_select_fields_from_table_order_by_descending
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT name FROM students ORDER BY age DESC", sqlSelect.field("name").from("students").order_by("age").desc().to_string
    end

    def test_select_fields_from_table_order_by_descending_and_ascending
        sqlSelect = SQUEL::Select.new
        assert_equal "SELECT name FROM students ORDER BY id DESC, name ASC", sqlSelect.field("name").from("students").order_by("id").desc().order_by("name").asc().to_string
    end
end