require "./spec_helper"

describe ReadOnly::List do
    describe "when adding new element" do
        it "returns list with the added element" do
            list = ReadOnly::List.new
            
            var result = list.add(3)

            result.count.should eq 1
        end
    end
end