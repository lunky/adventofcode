require 'spec_helper'
require 'digest' 
describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end
 
 describe "mine" do
   it "should have a calculate method" do
     theMine = Mine.new
     theMine.calculate("abc")
   end
   it "should take abcdef and return smallest hash that starts with 00000" do
     theMine = Mine.new
     expect(theMine.calculate("abcdef")).to eq(609043)
   end
   it "should calculate pqrstuv " do
     theMine = Mine.new
     expect(theMine.calculate("pqrstuv")).to eq(1048970)
   end
   it "should calculate iwrupvqb to 6 chars" do
     theMine = Mine.new
     theMine.key_length=6
     expect(theMine.calculate("iwrupvqb")).to eq(9958218)
   end
 end