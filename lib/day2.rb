class WrappingCalculator
    def calculate (dimension_string)
        dims = dimension_string.split("x")
        length, width, height= dims[0].to_i, dims[1].to_i, dims[2].to_i
        (2*length*width) + 
        (2*width*height) + 
        (2*height*length)
    end
    def calculate_ribbon(dimension_string) 
        dims = dimension_string.split("x")
        length, width, height= dims[0].to_i, dims[1].to_i, dims[2].to_i
        pair = [(2*length)+(2*width), 
                (2*width) + (2*height), 
                (2*height)+(2*length)].min 
        bow = length * width * height
        pair + bow 
    end
end 