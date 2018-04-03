require "./spec_helper"

describe ReadOnly::List do
    describe "when count is requested" do
        it "returns zero if there is no elements" do
            list = ReadOnly::List(Int32).new
            
            result = list.count

            result.should eq 0
        end
        it "returns the number of elements" do
            list = ReadOnly::List(Int32).new
            
            result = list.add(3).add(4).add(5)

            result.count.should eq 3
        end
    end

    describe "when adding new element" do
        it "returns new list with an added element" do
            list = ReadOnly::List(Int32).new
            
            result = list.add(3)

            result.count.should eq 1
        end

        it "returns new list with elements" do
            list = ReadOnly::List(Int32).new([1,2,3,4])

            result = list.add(3)

            result.count.should eq 5
        end

        it "returns new list with elements of another list" do
            list = ReadOnly::List(Int32).new([1,2,3,4])
            anotherList = ReadOnly::List(Int32).new([5,6,7,8,9])

            result = list.add(anotherList)

            result.count.should eq 9
        end
    end

    describe "when empty? is requested" do
        it "returns true if is empty" do
            list = ReadOnly::List(Int32).new

            result = list.empty?

            result.should eq true
        end

        it "returns false if is not empty" do
            list = ReadOnly::List(Int32).new.add(1).add(2)

            result = list.empty?

            result.should eq false
        end
    end

    describe "when sum is requested" do
        it "returns zero if is empty" do
            list = ReadOnly::List(Int32).new
            
            result = list.sum

            result.should eq 0
        end
    end
end