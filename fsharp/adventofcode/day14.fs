namespace adventofcode
open System

module Day14 =
    type Reindeer = {name: string; speed: int; duration: int; rest: int}

    let readReindeerRules (line:string) = 
        let chunks = line.Split [|' '|]
        {name=chunks.[0]; speed=Int32.Parse(chunks.[3]); duration=Int32.Parse(chunks.[6]); rest=Int32.Parse(chunks.[13])}
    
    // Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.              
    //        [{name="Comet"; speed=14; duration=10; rest=127}]
    let calculateDistance (reindeer :Reindeer) seconds = 
        let rec flyThenRest iterationCountdown accDistance countdownTimer = 
            match countdownTimer with
            |0 ->  accDistance
            |_ ->   match iterationCountdown with
                    |0 ->   flyThenRest (reindeer.rest + reindeer.duration) accDistance  (countdownTimer)    // resting
                    |t when t > reindeer.rest -> flyThenRest (iterationCountdown-1) (accDistance+1*reindeer.speed) (countdownTimer-1)  // flying
                    |_ ->   flyThenRest (iterationCountdown-1) accDistance (countdownTimer-1)     // resting

        flyThenRest (reindeer.rest + reindeer.duration) 0 seconds

    let getFastest rules time =
        let positions = rules |> Seq.map (fun line -> 
                            let rule = readReindeerRules line
                            let dist = calculateDistance rule time 
                            (dist, rule))
        let max = Seq.maxBy fst positions 
        positions |> Seq.where (fun x -> fst x = fst max) 

    let getWinner rules puzzleValue = 
        let rec Tick countdownTimer (acc : string list) = 
            match countdownTimer with
            | 0 -> acc
            | _ ->  (
                    let fastest = getFastest rules (puzzleValue - countdownTimer)
                    let winners = Seq.map (fun (a, reindeer) -> reindeer.name) fastest
                    let acc = acc @ Seq.toList winners
                    Tick (countdownTimer - 1) (acc)
                     )
        Tick puzzleValue []
                  