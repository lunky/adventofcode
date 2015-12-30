class Matchsticks
    def initialize
        @count = 0 
        @totes = 0 
    end
    
    def read(line)
        orig = line
        line = line.sub(/^\"(.*)\"$/,'\1')
        line = line.gsub(/\\\"/,'"')
        line = line.gsub(/\\\\/,'\\')
        line = line.gsub(/\\x([0-9A-Fa-f]{2})/) do
            $1.hex.chr
        end
        length = line.length
        @count += length
        @totes += orig.length
        length
    end
    
    def count
        @count
    end
    def totes
        @totes
    end
    def diff
        @totes - @count
    end
end
