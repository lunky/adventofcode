class Decider
    def judge(theString)
        isOk = true
        if ( theString !~ /((\w)\2)/ )
            isOk = false
        end
        if( theString =~ /ab|cd|pq|xy/)
            isOk = false
        end
        if( theString !~ /[aeiou].*[aeiou].*[aeiou]/)
            isOk = false
        end
       isOk 
    end
    def new_judgement(the_string)
       isOk = true
        if ( the_string !~ /((\w\w)(?=.*\2))/ )
            isOk = false
        end
        if ( the_string !~ /(.)([^\1])\1/ )
            isOk = false
        end
       isOk
    end
end
