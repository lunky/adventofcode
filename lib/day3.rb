class SantaHelper
    def deliver(instructions)
        parse(instructions);
        @Hash.keys.count
    end
    def robo_deliver(instructions)
        robo_parse(instructions);
        @Hash.keys.count
    end 
    def move(instruction, loc)
        case instruction
            when ">"
                loc[0]+=1
            when "<"
                loc[0]-=1
            when "^"
                loc[1]-=1
            when "v"
                loc[1]+=1
        end
        loc
    end
    
    def robo_parse(location_string)
        @Hash = {}
        loc = [ 0, 0 ]
        loc2 = [ 0, 0 ]
        add_loc(loc)
        location_string.split('').each_slice(2){|pair| 
                move(pair[0], loc);
                add_loc(loc)
                move(pair[1], loc2);
                add_loc(loc2)
        }
    end
    def parse(location_string)
        @Hash = {}
        loc = [ 0, 0 ]
        add_loc(loc)
        location_string.split('').each{|movement| 
            move(movement,loc)
            add_loc(loc)
        }
    end
    def add_loc(loc)
        key = "#{loc[0]}x#{loc[1]}"
        @Hash[key] = 1
    end
end