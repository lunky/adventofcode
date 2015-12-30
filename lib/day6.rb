class LightToggler
    def initialize
        @grid = Hash.new(0)
        @lit_up=0
        @brightness=0
    end
    def instruct(instruction)
        # parse instruction
        command = ""
        if instruction.start_with?("turn on") 
            command = :turn_on
            instruction = instruction.gsub!("turn on ", "")
        end
        if instruction.start_with?("turn off") 
            command = :turn_off
            instruction = instruction.gsub!("turn off ", "")
        end
        if instruction.start_with?("toggle")
            command = :toggle
            instruction = instruction.gsub!("toggle ", "")
        end
        start, finish= instruction
            .split(" through ").map{ |coord| coord.split(",")
            .map{|i| i.to_i }}
        for x in start[0]..finish[0] do
            for y in start[1]..finish[1] do
              change_light(command, [x,y]) 
            end
        end
    end
    def change_light(cmd, pt)
        on = (@grid[pt] == 1) 
        case(cmd)
            when :turn_on    
               @grid[pt] = 1
               @lit_up = (on ? @lit_up : @lit_up + 1)
               @brightness += 1
            when :turn_off
                @grid[pt] = 0
                @lit_up = (on ? @lit_up - 1 : @lit_up )
               @brightness = (@brightness >= 1 ? @brightness - 1 : @brightness)
            else
                @grid[pt] = (on ? 0 : 1)
                @lit_up = (on ? @lit_up - 1 : @lit_up + 1)
                @brightness += 2
        end
        
    end
    def lights_lit
       @lit_up
    end
    def brightness
       @brightness
    end
end