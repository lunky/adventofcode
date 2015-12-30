require 'spec_helper'

describe 'test system' do 
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end

describe "LightToggler" do
    before(:each) do
        @sut = LightToggler.new
    end 
    it "should respond to a command"  do
        @sut.instruct("turn on 0,0 through 999,999")   
    end
    it "should turn on all lights"  do
        @sut.instruct("turn on 0,0 through 999,999")   
        expect(@sut.lights_lit).to eq(1000*1000)
    end
    it "should turn on 1000 lights"  do
        @sut.instruct("toggle 0,0 through 999,0")
        expect(@sut.lights_lit).to eq(1000)
    end
    it "should turn on the middle four lights" do
        @sut.instruct("turn on 499,499 through 500,500")
        expect(@sut.lights_lit).to eq(4)
    end
    it "should turn off the middle four lights" do
        @sut.instruct("turn on 0,0 through 999,999")   
        expect(@sut.lights_lit).to eq(1000*1000)
        @sut.instruct("turn off 499,499 through 500,500")
        expect(@sut.lights_lit).to eq(1000*1000-4)
    end
    it "should increase by 1"  do
        @sut.instruct("turn on 0,0 through 0,0")
        expect(@sut.brightness).to eq(1)
    end
    it "should decrease by 1" do
        @sut.instruct("turn off 0,0 through 0,0")
        expect(@sut.brightness).to eq(0)
    end
    
    it "should increase by 2" do
        @sut.instruct("toggle 0,0 through 0,0")
        expect(@sut.brightness).to eq(2)
    end
    
    it "should increase by 2 then decrease by 1" do
        @sut.instruct("toggle 0,0 through 0,0")
        expect(@sut.brightness).to eq(2)
        @sut.instruct("turn off 0,0 through 0,0")
        expect(@sut.brightness).to eq(1)
    end
    it "should decrease by 1" do
        @sut.instruct("turn on 0,0 through 0,0")
        @sut.instruct("turn off 0,0 through 0,0")
        expect(@sut.brightness).to eq(0)
    end
    it "should increase by 20000"  do
        @sut.instruct("toggle 0,0 through 999,999")
        expect(@sut.brightness).to eq(2000000)
    end
end