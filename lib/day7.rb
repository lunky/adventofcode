class String
    def is_i?
       /\A[-+]?\d+\z/ === self
    end
end
MAX_VAL = 65536
class LogicGate
    def initialize
        @wires = Hash.new
        @pending = []
        @ran = false
    end
    def wires 
        @ran ? @wires : nil
    end
    def run
        retry_pending
        @ran=true
    end
    def instruct( instruction )
        begin
            do_the_thing(instruction)
       rescue  #todo catch correct exception
            @pending.push(instruction) # push intruction onto stack for reprocessing
        end
    end
    def do_the_thing(instruction)
        lhs,rhs = instruction.split('->').map{ |el| el.strip }
        tokens = lhs.split(' ').map(&:strip)
        lhs = evaluate(tokens)
        #puts "rhs #{rhs} lhs #{lhs} => #{instruction}"
        @wires[rhs] = lhs
    end
    def retry_pending
        #puts "@pending.length #{@pending.length}"
        c=0
        while @pending.length > 0 && c < 30000 do
            @pending.each do |el|
                c+=1
                #puts "retry instruction #{el}"
                begin
                self.do_the_thing el
                @pending.delete(el)
                rescue
                end
            end
        end
#        puts "processed #{c}"
    end
    
    def pending
        @pending
    end
    def evaluate(tokens)
        if(tokens.length==1)
           # puts "tokens #{tokens}"
            lhs = tokens.first
            if(!lhs.is_i?) 
                if(@wires.has_key?(lhs))
                    lhs = @wires[lhs]
                else
                    raise "Wire does not have a value #{lhs} : #{tokens}"
                end
            end 
            return lhs.to_i
        end
        if(tokens.length==2)
            operator, rhs = tokens
            if(!rhs.is_i?)
                if(@wires.has_key?(rhs))
                    rhs = @wires[rhs]
                else
                    raise "Wire does not have a value #{rhs} : #{tokens}"
                end
            end 
            if operator=="NOT"
                #puts " #{operator} #{rhs.to_i} #{~rhs.to_i}"
                answer = ~rhs.to_i
                if(answer<0) 
                    answer = MAX_VAL + answer
                end
                return answer
            end
            raise "invalid operator"
        end
        if(tokens.length==3)
            lhs, operator, rhs = tokens
            if(!lhs.is_i?)
                if(@wires.has_key?(lhs))
                    lhs = @wires[lhs]
                else
                    raise "Wire does not have a value #{lhs} : #{tokens}"
                end
            end 
            if(!rhs.is_i?)
                if(@wires.has_key?(rhs))
                    rhs = @wires[rhs]
                else
                    raise "Wire does not have a value #{rhs} : #{tokens}"
                end
            end 
            case operator
            when "AND"
             return lhs.to_i & rhs.to_i
            when "OR"
             return lhs.to_i | rhs.to_i
            when "LSHIFT"
             return lhs.to_i << rhs.to_i
            when "RSHIFT"
             return lhs.to_i >> rhs.to_i
            else
                raise "invalid operator"
            end
            
        end
        return tokens[0].to_i
    end
end