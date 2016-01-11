namespace adventofcode


module Day10 =

    let groupCharacters (str: string) =
        let breakIntoGroups (acc : char list list) c =
            let revAcc = List.rev acc
            //let lastElement = Seq.last acc
            let lastElement = Seq.head revAcc

            // if the lastElement is empty or it matches the last character added
            if Seq.isEmpty lastElement ||  c = Seq.head lastElement then
                // And add this character at the end
                let likeGroup = lastElement @ [ c ]
                // Finally put this updated group of like characters at the end of our accumulator
                let updatedAcc = likeGroup :: (List.tail revAcc)
                List.rev updatedAcc
            else
                acc @ [ [c] ]
        List.fold breakIntoGroups [ [] ] (Seq.toList str)

    let implode (xs: char seq) =
        let sb = System.Text.StringBuilder(Seq.length xs) 
        xs |> Seq.iter (sb.Append >> ignore)
        sb.ToString()

    let seeNSay (strz: string) =
        let s = groupCharacters strz |> Seq.map (fun grp -> sprintf "%i%c" (Seq.length grp) (Seq.head grp) ) 
        let sb = new System.Text.StringBuilder(Seq.length s);
        s |> Seq.iter (sb.Append >> ignore);
        sb.ToString()
        