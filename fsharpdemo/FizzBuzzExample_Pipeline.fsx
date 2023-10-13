// =============================================
// Pipeline oriented fizzbuzz
// =============================================

type FizzBuzzData =
    { Output:string; Number:int }

/// A generic step to handle 3,5 etc
let handle divisor output data =
    if data.Output <> "" then
        data // already processed
    elif data.Number % divisor <> 0 then
        data // not applicable
    else
        {Output=output; Number=data.Number}


let finalStep data =
    if data.Output <> "" then
        data.Output // already processed
    else
        data.Number.ToString()


// something else to put in the pipeline
let logger message data =
    printfn "%s: %A" message data
    data

let fizzBuzzPipeline i =
    {Output=""; Number=i}
    |> handle 15 "FizzBuzz"
    |> handle 3 "Fizz"
    |> handle 5 "Buzz"
    |> finalStep


let fizzBuzz() =
    [1..35]
    |> List.map fizzBuzzPipeline
    |> String.concat ","
    |> printfn "%s"


fizzBuzz()


// =============================================
// Demonstrates a parallel fizzbuzz
// =============================================

let combineData data1 data2 =
    {Output= data1.Output + data2.Output; Number=data1.Number}

let fizzBuzzParallelHandler i =

    let initialData = {Output=""; Number=i}

    let handlers = [
        handle 3 "Fizz"
        handle 5 "Buzz"
        handle 7 "Zap"
    ]

    handlers
    |> List.map (fun handler -> handler initialData)
    |> List.reduce combineData
    |> finalStep

let fizzBuzzParallel() =
    [1..35]
    |> List.map fizzBuzzParallelHandler
    |> String.concat ","
    |> printfn "%s"

fizzBuzzParallel()

