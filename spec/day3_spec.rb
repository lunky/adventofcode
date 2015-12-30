require 'spec_helper'

describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end

describe SantaHelper do
    it("should parse < ") do
        sut = SantaHelper .new
        resp = sut.deliver("<")
        expect(resp).to eq(2) 
    end
    it("should parse ^>v< ") do
        sut = SantaHelper .new
        resp = sut.deliver("^>v<")
        expect(resp).to eq(4) 
    end
    it("should parse ^v^v^v^v^v ") do
        sut = SantaHelper .new
        resp = sut.deliver("^v^v^v^v^v")
        expect(resp).to eq(2) 
    end
    it("should parse ^v ") do
        sut = SantaHelper .new
        resp = sut.robo_deliver("^v")
        expect(resp).to eq(3)
    end
    it("should parse ^>v< ") do
        sut = SantaHelper .new
        resp = sut.robo_deliver("^>v<")
        expect(resp).to eq(3)
    end
    it("should parse ^v^v^v^v^v ") do
        sut = SantaHelper .new
        resp = sut.robo_deliver("^v^v^v^v^v")
        expect(resp).to eq(11) 
    end
end