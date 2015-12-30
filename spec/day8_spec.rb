require 'spec_helper'

describe "tests" do
   it "can run a test" do
       expect(6).to eq(6)
   end
end

describe "Matchsticks" do
    before(:each) do
        @sut = Matchsticks.new
    end
    
    it "should be able to read a line" do
        line = ""
        @sut.read(line)
    end
    
    it "should be able to get a count" do
        line = ""
        @sut.read(line)
        expect(@sut.count).to eq(0)
    end
    
    it "should be able to get a count of abc" do
        line = "abc"
        @sut.read(line)
        expect(@sut.count).to eq(3)
    end
    
    it "should be able to get a count of \"\" " do
        line = "\"\""
        @sut.read(line)
        expect(@sut.count).to eq(0)
    end
    
    it "should be able to get a count of \"abc\" " do
        line = "\"abc\""
        @sut.read(line)
        expect(@sut.count).to eq(3)
    end
    
    it "should be able to ignore escaped char \" inside a string" do
    #"aaa\"aaa" is 10 characters of code, but the string itself contains six "a" characters and a single, escaped quote character, for a total of 7 characters in the string data.
        line = "\"aaa\\\"aaa\""
        @sut.read(line)
        expect(@sut.count).to eq(7)
    end
    
    it "should escaped hex character \\x27 " do
        #"\x27" is 6 characters of code, but the string itself contains just one - an apostrophe ('), escaped using hexadecimal notation.
        line = "\"\\x27\""
        @sut.read(line)
        expect(@sut.count).to eq(1)
    end
         
    it "should escape hex character abc\\x27def " do
        line = "\"abc\\x27def\""
        @sut.read(line)
        expect(@sut.count).to eq(7)
    end
    
    it "should handle multiple escaped characters" do
        line = "\"a\\xd2v\\\"k\\\"mpcu\\\"yyu\\\"en\""
        @sut.read(line)
        expect(@sut.count).to eq(17)
    end
    
    it "should count chars before into @totes" do
        line = "\"xziq\\\x18ybyv\x9am\"neacoqjzytertisysza\""
        line = "\"xziq\\\\\\x18ybyv\\x9am\\\"neacoqjzytertisysza\""
        @sut.read(line)
        expect(@sut.count).to eq(33)
        expect(@sut.totes).to eq(42)
    end
    
    it "should count chars before into @totes" do
        @sut.read("\"\"")
        expect(@sut.totes).to eq(2)
        expect(@sut.count).to eq(0)
        @sut.read("\"abc\"")
        expect(@sut.totes).to eq(7)
        expect(@sut.count).to eq(3)
        @sut.read("\"aaa\\\"aaa\"")
        expect(@sut.totes).to eq(17)
        expect(@sut.count).to eq(10)
        @sut.read("\"\\x27\"")
        expect(@sut.totes).to eq(23)
        expect(@sut.count).to eq(11)
        expect(@sut.diff).to eq(12)
    end
end