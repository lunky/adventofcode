require "./lib/day3"
helper = SantaHelper.new
contents = File.read("./data/day3data.txt")
res = helper.deliver(contents) 
puts "res = #{res}"
contents = File.read("./data/day3data.txt")
res = helper.robo_deliver(contents) 
puts "robo res = #{res}"
