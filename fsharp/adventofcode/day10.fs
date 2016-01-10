namespace adventofcode


module Day10 =
    let breakIntoGroups (acc : char list list) c =
        let revAcc = List.rev acc
        let lastElement = Seq.last acc

        // if the lastElement is empty or it matches the last character added
        if Seq.isEmpty lastElement ||  c = Seq.head lastElement then
            // And add this character at the end
            let likeGroup = lastElement @ [ c ]
            // Finally put this updated group of like characters at the end of our accumulator
            let updatedAcc = likeGroup :: (List.tail revAcc)
            List.rev updatedAcc
        else
            acc @ [ [c] ]

