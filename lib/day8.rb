class Matchsticks
    def initialize
        @count = 0 
        @totes = 0 
        @encoded = 0
    end
    
    def read(line)
        @totes += line.length
#        puts "#{line} totes #{line.length}"
        line = line.sub(/^\"(.*)\"$/,'\1')
        orig = line
        line = line.gsub(/\\\"/,'"')
        line = line.gsub(/\\\\/,'\\')
        line = line.gsub(/\\x([0-9A-Fa-f]{2})/) do
            $1.hex.chr
        end
        length = line.length
        @count += length
        reencoded = orig
        reencoded = reencoded.gsub("\\","\\\\\\\\")
        reencoded = reencoded.gsub("\"","\\\\\"")
        reencoded = reencoded.gsub(/\\x([0-9A-Fa-f]{2})/) do
           "\\x#{$1}"
        end
        reencoded = "\"\\\"#{reencoded}\\\"\"" # add quotes around the outside
#        puts "line: ~#{line}~ reencoded: ~#{reencoded}~ #{reencoded.length}"
        @encoded = @encoded + reencoded.length
        @curr_encoded = reencoded.length
        length
    end
    
    def count
        @count
    end
    def totes
        @totes
    end
    def encoded
        @encoded
    end
    def curr_encoded
        @curr_encoded
    end
    def diff
        @totes - @count
    end
    def reencoded_diff
        #(@totes - @encoded).abs
        (@encoded - @totes).abs
    end
end
