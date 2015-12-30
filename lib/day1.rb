class   SantaElevator 
    attr_reader :firstMinusOne
   def deliver(instructions) 
        instr = instructions.split('')
        reduced = instr.each_with_index.inject(0){|sum, pair| 
            el,idx = pair
#            puts idx
            case el 
            when '('
                sum += 1
            when ')' 
                sum -= 1
           end 
           if sum==-1 && @firstMinusOne == nil
               @firstMinusOne = idx+1
           end
          sum 
        }
   end
   
end