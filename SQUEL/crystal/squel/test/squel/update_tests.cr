require "minitest/autorun"

require "../../src/squel/update.cr"

class UpdateTest < Minitest::Test
    def test_update_fields_from_table
        sqlUpdate = SQUEL::Update.new

        assert_equal "UPDATE students SET name = 'Fred', age = 29, score = 1.2, graduate = false", sqlUpdate.table("students").set("name", "'Fred'").set("age", 29).set("score", 1.2).set("graduate", false).to_string
    end
end