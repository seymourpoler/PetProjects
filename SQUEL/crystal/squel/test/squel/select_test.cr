require "minitest/autorun"

require "../../src/squel/select.cr"
require "../../src/squel/fields_builder.cr"
require "../../src/squel/table_builder.cr"
require "../../src/squel/limit_builder.cr"
require "../../src/squel/offset_builder.cr"
require "../../src/squel/order_builder.cr"
require "../../src/squel/group_builder.cr"
require "../../src/squel/string_joiner.cr"

class SelectTest < Minitest::Test
    def test_select_all_from_table
        sqlSelect = SQUEL::Select.new

        assert_equal "SELECT * FROM students", sqlSelect.from("students").to_string
    end

    def test_select_one_field_from_table
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id FROM students", sqlSelect.field("id").from("students").to_string
    end

    def test_select_distinct_field_from_table
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT DISTINCT id FROM students", sqlSelect.field("id").distinct().from("students").to_string
    end

    def test_select_fields_from_table
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students", sqlSelect.field("id").field("name").from("students").to_string
    end

    def test_select_all_fields_from_tables
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT * FROM students, admins ad, users", sqlSelect.from("students").from("admins", "ad").from("users").to_string
    end

    def test_select_fields_from_table_with_acronimus
        sqlSelect = SQUEL::Select.new
       
        assert_equal "SELECT id, name FROM students s", sqlSelect.field("id").field("name").from("students", "s").to_string
    end

    def test_select_fields_with_acronimus_from_table
        sqlSelect = SQUEL::Select.new
       
        assert_equal "SELECT identificator AS 'id', name FROM students s", sqlSelect.field("identificator", "id").field("name").from("students", "s").to_string
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
        
        assert_equal "SELECT id, name FROM students ORDER BY id DESC, name ASC", sqlSelect.field("id").field("name").from("students").order_by("id").desc().order_by("name").asc().to_string
    end

    def test_select_fields_from_table_group_by
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students GROUP BY email", sqlSelect.field("id").field("name").from("students").group("email").to_string
    end

    def test_select_fields_from_table_with_condition
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students WHERE email = 'a@a.es'", sqlSelect.field("id").field("name").from("students").where("email = 'a@a.es'").to_string
    end

    def test_select_fields_from_table_with_conditions
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students WHERE email = 'a@a.es' AND age > 18", sqlSelect.field("id").field("name").from("students").where("email = 'a@a.es'").where("age > 18").to_string
    end

    def test_select_fields_from_table_with_inner_join
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students INNER JOIN teachers", sqlSelect.field("id").field("name").from("students").join("teachers").to_string
    end

    def test_select_fields_from_table_with_inner_join_with_acronimus
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students INNER JOIN teachers t", sqlSelect.field("id").field("name").from("students").join("teachers", "t").to_string
    end

    def test_select_fields_from_table_with_outer_join
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students OUTER JOIN teachers", sqlSelect.field("id").field("name").from("students").outer_join("teachers").to_string
    end

    def test_select_fields_from_table_with_outer_join_with_acronimus
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students OUTER JOIN teachers t", sqlSelect.field("id").field("name").from("students").outer_join("teachers", "t").to_string
    end

    def test_select_fields_from_table_with_inner_join_and_with_outer_join
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students INNER JOIN teachers OUTER JOIN users", sqlSelect.field("id").field("name").from("students").join("teachers").outer_join("users").to_string
    end

    def test_select_fields_from_table_with_left_join
        sqlSelect = SQUEL::Select.new
        
        assert_equal "SELECT id, name FROM students LEFT JOIN teachers ON (students.id = teachers.student_id)", sqlSelect.field("id").field("name").from("students").left_join("teachers", "students.id = teachers.student_id").to_string
    end
end