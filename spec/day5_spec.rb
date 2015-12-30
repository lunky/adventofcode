 require 'spec_helper'

describe 'test system' do
  it "should run simple test" do
    foo = 3
    expect(foo).to be(3)
  end
 end
  
 describe 'Xmas Decider' do
     it 'should find string nice' do
        decider = Decider.new
        expect(decider.judge("ugknbfddgicrmopn")).to be(true)
     end
     it 'should find the string "aaa" nice too' do
        decider = Decider.new
        expect(decider.judge("aaa")).to be(true)
     end
     it 'should have at least three vowels in it' do
        decider = Decider.new 
        expect(decider.judge("ugknbfddgrcrmopn")).to be(false)
     end
     it 'should have at least three vowels in it' do
        decider = Decider.new 
        expect(decider.judge("ugknbfddgicrmopn")).to be(true)
     end
     it 'should find the string "jchzalrnumimnmhp" naughty because no double leters' do
        decider = Decider.new
        expect(decider.judge("jchzalrnumimnmhp")).to be(false)
     end
     it 'should find the string "haegwjzuvuyypxyu" naughty because it has xy in it' do
        decider = Decider.new
        expect(decider.judge("haegwjzuvuyypxyu")).to be(false)
     end
     it 'should find the string "dvszwmarrgswjxmb" naughty b/c it only has one vowel' do
        decider = Decider.new
        expect(decider.judge("dvszwmarrgswjxmb")).to be(false)
     end
     it 'should use new_judgement to check if qjhvhtzxzqqjkmpb is naughty' do
         decider = Decider.new
        expect(decider.new_judgement("qjhvhtzxzqqjkmpb ")).to be(true)
     end
     it 'should use new_judgement to check if xxyxx is naughty' do
         decider = Decider.new
        expect(decider.new_judgement("xxyxx")).to be(true)
     end
     it 'should use new_judgement to check if uurcxstgmygtbstgx is naughty' do
         decider = Decider.new
        expect(decider.new_judgement("uurcxstgmygtbstg")).to be(false)
     end
     
 end