require "./lib/day5"
decider = Decider.new
contents = File.readlines("./data/day5data.txt")
count = contents.inject(0){ |sum, line|
    res = decider.judge(line) 
    if(res)
        sum+1
    else 
        sum
    end
}
puts "count = #{count}"
count = contents.inject(0){ |sum, line|
    res = decider.new_judgement(line) 
    if(res)
        sum+1
    else 
        sum
    end
}
puts "count = #{count}"