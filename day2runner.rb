require "./lib/day2"
calc= WrappingCalculator.new
contents = File.readlines("./data/day2data.txt")
count = contents.inject(0){ |sum, line|
    res = calc.calculate_ribbon(line) 
}
puts "count = #{count}"