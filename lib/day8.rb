class Matchsticks
    def initialize
        @count = 0 
        @totes = 0 
    end
    
    def read(line)
        linelength = line.length 
        foundChar = /\\x(..)/ =~ line 
        foundHex = /\\x([0-9a-fA-F]{2})/ =~ line 
        print " ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~foundHex ~#{foundHex}~" if (foundChar && !foundHex)
        @totes = @totes + linelength
        print ":::##{line}# length:#{linelength} "
        line = line.sub(/^\"(.*)\"$/,'\1')
        line = line.gsub(/\\\"/,'"')
        line = line.gsub(/\\x([0-9A-Fa-f]{2})/) do
            $1.hex.chr
        end
        length = line.length
        puts " => ##{line}# length:#{length}" 
        @count += length
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
