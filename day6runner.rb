require "./lib/day6"
toggler = LightToggler.new

contents = File.readlines("./data/day6data.txt")
count = contents.each {|line|
    toggler.instruct(line)
} 
puts "@sut.lights_lit = #{toggler.lights_lit}"
puts "@sut.brightness= #{toggler.brightness}"