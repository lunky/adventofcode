class Mine 
    attr_accessor :key_length
    def initialize
        @key_length = 5
    end
 def calculate(key)
    hash = ""
    counter=-1 
    #puts "0"*@key_length 
    while(hash[0,@key_length]!="0"*@key_length) 
       counter+=1
       hash = Digest::MD5.hexdigest( key + counter.to_s)
    end
    counter
 end
end

