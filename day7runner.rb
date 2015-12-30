require "./lib/day7"
gate = LogicGate.new

contents = File.readlines("./data/day7data.txt")
count = contents.each {|line|
    gate.instruct(line)
} 
gate.run

puts "gate.wires[\"a\"] = #{ gate.wires['a'] }" 
gate = LogicGate.new
count = contents.each {|line|
    if  line.start_with?("14146 -> b")
        gate.instruct("956 -> b")
    else
        gate.instruct(line)
    end

} 
gate.run
puts "gate.wires[\"a\"] = #{ gate.wires['a'] }" 