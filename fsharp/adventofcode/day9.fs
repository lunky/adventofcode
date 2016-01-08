namespace adventofcode


module Day9  = 
    type CityDistance = {
        city1: string;        city2: string;        distance : int;
    }

    /// 
    let getSegments (cityList) =
        [ for city in cityList do 
            yield Seq.pairwise city ] 

        // returns matching CityDistance if you give a route
    let cityLookup (route: string*string) (source: CityDistance seq) : CityDistance = 
        let start = fst route
        let dest = snd route
        let leg = Seq.find( fun el -> (el.city1 = start && el.city2 = dest) || (el.city2=start && el.city1=dest)) source
        {city1= start; city2= dest; distance=leg.distance}

    // returns a unique list of city names
    let distinctCities (cities: CityDistance list) =
        List.collect (fun x -> [x.city2; x.city1]) cities
        |> Seq.distinct   
        |> Seq.toList  

    /// Rotates a list by one place forward.
    let rotate lst =
        List.tail lst @ [List.head lst]

    /// Gets all rotations of a list.
    let getRotations lst =
        let rec getAll lst i = if i = 0 then [] else lst :: (getAll (rotate lst) (i - 1))
        getAll lst (List.length lst)

    /// Gets all permutations (without repetition) of specified length from a list.
    let rec getPerms n lst = 
        match n, lst with
        | 0, _ -> seq [[]]
        | _, [] -> seq []
        | k, _ -> lst |> getRotations |> Seq.collect (fun r -> Seq.map ((@) [List.head r]) (getPerms (k - 1) (List.tail r)))

    

    let shortestRoute (cities: CityDistance list) = 
        let ctz = distinctCities cities 
        let permutations = ctz |> getPerms ctz.Length   
        let mapped = getSegments permutations |> List.map (fun segment -> (Seq.map ( fun el -> (cityLookup el cities) ) segment ))
        Seq.minBy (fun leg -> Seq.sumBy (fun  x ->  x.distance) leg ) mapped 

    let longestRoute (cities: CityDistance list) = 
        let ctz = distinctCities cities 
        let permutations = ctz |> getPerms ctz.Length   
        let mapped = getSegments permutations |> List.map (fun segment -> (Seq.map ( fun el -> (cityLookup el cities) ) segment ))
        Seq.maxBy (fun leg -> Seq.sumBy (fun  x ->  x.distance) leg ) mapped 

    let longestDistance (cities: CityDistance list) = 
        longestRoute cities |> Seq.sumBy (fun  x ->  x.distance)

    let shortestDistance (cities: CityDistance list) = 
        shortestRoute cities |> Seq.sumBy (fun  x ->  x.distance)

//    member this.X = "F#"
