 require 'spec_helper'

describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end
 
describe "Santa Elevator" do
    it("should return the floor 0") do
        sut = SantaElevator.new()
        result = sut.deliver("(())")
        expect(result).to eq(0)
    end
    it("should return floor 3") do 
        sut = SantaElevator.new()
        result = sut.deliver("(((")
        expect(result).to eq(3)
    end
    it("should also return floor 3") do 
        sut = SantaElevator.new()
        result = sut.deliver("(()(()(")
        expect(result).to eq(3)
    end
    it("should also also return floor 3") do 
        sut = SantaElevator.new()
        result = sut.deliver("))(((((")
        expect(result).to eq(3)
    end
    it("should return -1") do
        sut = SantaElevator.new()
        result = sut.deliver("))(")
        expect(result).to eq(-1)
    end
    it("should return the index of the first -1 = 5") do
        sut = SantaElevator.new() 
        result = sut.deliver("()())")
        expect(sut.firstMinusOne).to eq(5) 
    end
    it("should return the index of the first -1 = 1") do
        sut = SantaElevator.new()
        result = sut.deliver(")") 
        expect(sut.firstMinusOne).to eq(1)
    end
    it("should return the index of the first -1 = 5") do
        sut = SantaElevator.new()
        result = sut.deliver("(()))")
        expect(sut.firstMinusOne).to eq(5)
    end
end