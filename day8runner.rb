require "./lib/day8"
obj = Matchsticks.new

contents = File.readlines("./data/day8data.txt")
count = contents.inject(0){|counter, line|
    length = obj.read(line.chomp)
#    puts "#{line.chomp} : #{obj.curr_encoded}"
    counter + length
} 
puts "Total = #{obj.count} #{count}"
puts "Overall Total = #{obj.totes} #{count}"
puts "diff = #{obj.diff}"
puts "reencoded = #{obj.encoded}"
puts "reencoded diff = #{obj.reencoded_diff}"
