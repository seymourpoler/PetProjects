require "minitest/autorun"

require "../../src/squel/delete.cr"

class DeleteTest < Minitest::Test
    def test_
        sqlDelete = SQUEL::Delete.new

        assert_equal "DELETE FROM students", sqlDelete.from("students").to_string
    end
end