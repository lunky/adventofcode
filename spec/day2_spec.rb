require 'spec_helper'

describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end

describe WrappingCalculator do
    it("should calculate area of wrapping paper for 2x3x4 input") do
        sut = WrappingCalculator.new
        resp = sut.calculate("2x3x4")
        expect(resp).to eq(52)
    end
    it("should calculate area of wrapping paper for 1x1x10 input") do
        sut = WrappingCalculator.new
        resp = sut.calculate("1x1x10")
        expect(resp).to eq(42)
    end
    it("should calculate ribbon for 2x3x4") do
        sut = WrappingCalculator.new
        resp = sut.calculate_ribbon("2x3x4")
        expect(resp).to eq(34)
    end
    it("should calculate ribbon for 1x1x10") do
        sut = WrappingCalculator.new
        resp = sut.calculate_ribbon("1x1x10")
        expect(resp).to eq(14)
    end
end