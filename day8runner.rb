require "./lib/day8"
obj = Matchsticks.new

contents = File.readlines("./data/day8data.txt")
print "length "
count = contents.inject(0){|counter, line|
    length = obj.read(line.chomp)
    counter + length
} 
puts "Total = #{obj.count} #{count}"
puts "Overall Total = #{obj.totes} #{count}"
puts "diff = #{obj.diff}"
