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

            result.should be_true
        end

        it "returns false if is not empty" do
            list = ReadOnly::List(Int32).new.add(1).add(2)

            result = list.empty?

            result.should be_false
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

            result.empty?.should be_true
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

            result.should be_false
        end

        it "returns false if have not the same of elements" do
            listOne = ReadOnly::List(Int32).new.add(1).add(2).add(3).add(4)
            listTwo = ReadOnly::List(Int32).new.add(1).add(2).add(4).add(3)

            result = listOne.equal?(listTwo)

            result.should be_false
        end

        it "returns true if have the same elements" do
            listOne = ReadOnly::List(Int32).new.add(1).add(2).add(3)
            listTwo = ReadOnly::List(Int32).new.add(1).add(2).add(3)

            result = listOne.equal?(listTwo)

            result.should be_true
        end
    end

    describe "when addAt is requested" do
        it "returns the same list if is an empty list" do
            list = ReadOnly::List(Int32).new

            result = list.addAt(2, 5)

            result.empty?.should be_true
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

            result.equal?(ReadOnly::List(Int32).new([3, 4])).should be_true
        end
    end

    describe "when reverse is requested" do
        it "returns the same list if is empty" do
            list = ReadOnly::List(Int32).new

            result = list.reverse

            result.equal?(list = ReadOnly::List(Int32).new).should be_true
        end

        it "returns new reversed list" do
            list = ReadOnly::List(Int32).new([1,2,3,4])

            result = list.reverse

            result.equal?(list = ReadOnly::List(Int32).new([4,3,2,1])).should be_true
        end

    end

    describe "when select is requested" do
        it "returns new list if is empty" do
            list = ReadOnly::List(Int32).new

            result = list.select{ |x| x.to_s }

            result.equal?(ReadOnly::List(String).new).should be_true
        end

        it "returns new selected list" do
            list = ReadOnly::List(Int32).new([1,2,3])

            result = list.select{ |x| x.to_s }

            result.equal?(ReadOnly::List(String).new(["1", "2", "3"])).should be_true
        end
    end

    describe "when remove is requested" do
        it "returns new list without removed elements" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            result = list.remove{|x| x > 2}

            result.equal?(ReadOnly::List(Int32).new([3,4,5,6])).should be_true
        end
    end

    describe "when removeAt is requested" do
        it "returns the same list if position is minus than zero" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            result = list.removeAt(-2) 

            result.equal?(list).should be_true
        end

        it "returns the same list if position is major than length of the list" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            result = list.removeAt(8) 

            result.equal?(list).should be_true
        end

        it "returns new list without the element at position" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5])

            result = list.removeAt(2) 

            result.equal?(ReadOnly::List(Int32).new([1,2,4,5])).should be_true
        end
    end
    
    describe "when clear is requested" do
        it "returns an empty list" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            result = list.clear

            result.equal?(list = ReadOnly::List(Int32).new).should be_true
        end
    end

    describe "when elementAt is requested" do
        it "raise IndexError if position is minus than zero" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            expect_raises IndexError do 
                list.elementAt(-2)
            end
        end

        it "raise IndexError if position is major than length of list" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            expect_raises IndexError do 
                list.elementAt(14)
            end
        end

        it "returns element at position" do
            list = ReadOnly::List(Int32).new([1,2,3,4,5,6])

            result = list.elementAt(2)
            
            result.should eq 3
        end
    end

    describe "when first is requested" do
        it "returns nil if is empty list" do
            list = ReadOnly::List(Int32).new

            result = list.first{ |x| x > 2}

            result.should be_nil
        end

        it "returns nil if there is no first element that satisfied the condition" do
            list = ReadOnly::List(Int32).new([1,2,2,3,4,5])

            result = list.first{ |x| x > 20 }

            result.should be_nil
        end

        it "returns the first element that satisfied  the condition" do
            list = ReadOnly::List(Int32).new([1,2,2,3,4,5])

            result = list.first{ |x| x > 2 }

            result.should eq 3
        end
    end

    describe "when last is requested" do
        it "returns nil if is empty list" do
            list = ReadOnly::List(Int32).new

            result = list.last{ |x| x > 2}

            result.should be_nil
        end

        it "returns nil if there is no last element that satisfied the condition" do
            list = ReadOnly::List(Int32).new([1,2,2,3,4,5])

            result = list.last{ |x| x > 20 }

            result.should be_nil
        end

        it "returns the last element that satisfied  the condition" do
            list = ReadOnly::List(Int32).new([1,2,2,3,4,5])

            result = list.last{ |x| x > 2 }

            result.should eq 5
        end
    end

    describe "when order by ascending is requested" do
        it "returns the same list if has no integers" do
            list = ReadOnly::List(String).new(["h", "e", "l", "o"])

            result = list.order_by_ascending

            result.equal?(list).should be_true
        end
    end

end