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

        it "returns the sum of values Int32" do
            list = ReadOnly::List(Int32).new.add(1).add(2).add(3)

            result = list.sum

            result.should eq 6
        end

        it "returns zero if there is no numbers" do
            list = ReadOnly::List(String).new.add("Helo").add("every").add("body")

            result = list.sum
            
            result.should eq 0
        end
    end

    describe "when take is requested" do
        it "return empty list when there is no elements" do
            list = ReadOnly::List(String).new
        
            result = list.take 3

            result.empty?.should eq true
        end

        it "return the same list if the number of taking requested is minus than one" do
            list = ReadOnly::List(Int32).new.add(1).add(2).add(3)

            result = list.take(0)

            result.equal?(ReadOnly::List.new([1, 2, 3]))
        end

        it "return new list with taken elements" do
            list = ReadOnly::List(Int32).new.add(1).add(2).add(3)

            result = list.take(2)

            result.equal?(ReadOnly::List.new([1,2]))
        end
    end

    describe "when equal? is requested" do
        it "returns false if have not the same number of elements" do
            listOne = ReadOnly::List(Int32).new.add(1).add(2).add(3).add(4)
            listTwo = ReadOnly::List(Int32).new.add(1).add(2).add(4)

            result = listOne.equal?(listTwo)

            result.should eq false
        end

        it "returns false if have not the same of elements" do
            listOne = ReadOnly::List(Int32).new.add(1).add(2).add(3).add(4)
            listTwo = ReadOnly::List(Int32).new.add(1).add(2).add(4).add(3)

            result = listOne.equal?(listTwo)

            result.should eq false
        end

        it "returns true if have the same elements" do
            listOne = ReadOnly::List(Int32).new.add(1).add(2).add(3)
            listTwo = ReadOnly::List(Int32).new.add(1).add(2).add(3)

            result = listOne.equal?(listTwo)

            result.should eq true
        end
    end

    describe "when addAt is requested" do
        it "returns the same list if is an empty list" do
            list = ReadOnly::List(Int32).new

            result = list.addAt(2, 5)

            result.empty?.should eq true
        end

        it "returns the same list if the position is minor than zero" do
            list = ReadOnly::List(Int32).new([1, 2, 3, 4])

            result = list.addAt(-1, 5)

            result.equal?(ReadOnly::List(Int32).new([1, 2, 3, 4])).should eq true
        end

        it "returns the same list if the position is major than the size of the list" do
            list = ReadOnly::List(Int32).new([1, 2, 3, 4])

            result = list.addAt(10, 5)

            result.equal?(ReadOnly::List(Int32).new([1, 2, 3, 4])).should eq true
        end

        it "returns new list with the element at the end" do
            list = ReadOnly::List(Int32).new([1, 2, 3, 4])

            result = list.addAt(4, 5)

            result.equal?(ReadOnly::List(Int32).new([1, 2, 3, 4, 5])).should eq true
        end

        it "returns new list with the element at the beginning" do
            list = ReadOnly::List(Int32).new([1, 2, 3, 4])

            result = list.addAt(0, 5)

            result.equal?(ReadOnly::List(Int32).new([5, 1, 2, 3, 4])).should eq true
        end
    end

    describe "when where is requested" do
        it "returns new list with filtered elements" do
            list = ReadOnly::List(Int32).new([1, 2, 3, 4])

            result = list.where{ |x| x > 2 }

            result.equal?(ReadOnly::List(Int32).new([3, 4])).should eq true
        end
    end

    describe "when reverse is requested" do
        it "returns the same list if is empty" do
            list = ReadOnly::List(Int32).new

            result = list.reverse

            result.equal?(list = ReadOnly::List(Int32).new).should eq true
        end

        it "returns new reversed list" do
            list = ReadOnly::List(Int32).new([1,2,3,4])

            result = list.reverse

            result.equal?(list = ReadOnly::List(Int32).new([4,3,2,1])).should eq true
        end

    end
end