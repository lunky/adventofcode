 require 'spec_helper'

describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end
 
 describe 'LogicGate' do
    before(:each) do
        @sut = LogicGate.new
    end 
    
     it "should do nothing till you run it" do
        @sut.instruct("123 -> x") 
        expect(@sut.wires).to eq(nil) 
     end
     
     it "should parse the syntax of a command x -> 123" do
        @sut.instruct("123 -> x") 
        @sut.run
        expect(@sut.wires["x"]).to eq(123)
     end
     
     it "should parse the syntax of a command 456 -> y" do
        @sut.instruct("456 -> y") 
        @sut.run
        expect(@sut.wires["y"]).to eq(456)
     end
     
     it "should parse an expression in the lhs x AND y -> d" do
        @sut.instruct("123 -> x") 
        @sut.instruct("456 -> y") 
        @sut.instruct("x AND y -> d") 
        @sut.run
        expect(@sut.wires["d"]).to eq(72)
    end
     it "should parse an expression in the lhs x OR y -> e" do
        @sut.instruct("123 -> x") 
        @sut.instruct("456 -> y") 
        @sut.instruct("x OR y -> e")
        @sut.run
        expect(@sut.wires["e"]).to eq(507)
    end
     it "should parse an expression in the lhs x LSHIFT 2 -> f" do
        @sut.instruct("123 -> x") 
        @sut.instruct("x LSHIFT 2 -> f")
        @sut.run
        expect(@sut.wires["f"]).to eq(492)
    end
     it "should parse an expression in the lhs y RSHIFT 2 -> g" do
        @sut.instruct("456 -> y") 
        @sut.instruct("y RSHIFT 2 -> g")
        @sut.run
        expect(@sut.wires["g"]).to eq(114)
    end
    
     it "should parse an expression in the lhs y RSHIFT 2 -> g" do
        @sut.instruct("123 -> x") 
        @sut.instruct("NOT x -> h")
        @sut.run
        expect(@sut.wires["h"]).to eq(65412)
    end
    
     it "should parse an expression series 1" do
        @sut.instruct(" 123 -> x")
        @sut.instruct("456 -> y")
        @sut.instruct("x AND y -> d")
        @sut.instruct("x OR y -> e")
        @sut.instruct("x LSHIFT 2 -> f")
        @sut.instruct("y RSHIFT 2 -> g")
        @sut.instruct("NOT x -> h")
        @sut.instruct("NOT y -> i")
        @sut.instruct("y -> z")
        @sut.run
        
        expect(@sut.wires["d"]).to eq(72)
        expect(@sut.wires["e"]).to eq( 507 )
        expect(@sut.wires["f"]).to eq( 492 )
        expect(@sut.wires["g"]).to eq( 114 )
        expect(@sut.wires["h"]).to eq( 65412 )
        expect(@sut.wires["i"]).to eq( 65079 )
        expect(@sut.wires["x"]).to eq( 123 )
        expect(@sut.wires["y"]).to eq( 456 )
        expect(@sut.wires["z"]).to eq( 456 )
    end
 end
 
 
 