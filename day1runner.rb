require "./lib/day1"
elevator = SantaElevator.new
contents = File.read("./data/day3data.txt")
res = elevator.deliver(contents) 
puts "result = #{res}"
puts "first -1= #{elevator.firstMinusOne}"
