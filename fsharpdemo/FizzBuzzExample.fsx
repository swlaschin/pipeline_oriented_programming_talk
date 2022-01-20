// =============================================
// Demonstrates the classic FizzBuzz
// =============================================

module FizzBuzzExample1 =

    let fizzBuzz() =
        for i in [1..30] do
            if (i % 15 = 0) then
                printf "FizzBuzz,"
            elif (i % 3 = 0) then 
                printf "Fizz,"
            elif (i % 5 = 0) then
                printf "Buzz,"
            else
                printf $"{i},"
        printfn ""


FizzBuzzExample1.fizzBuzz()


// =============================================
// Demonstrates breaking down into steps
// =============================================

type FizzBuzzData = 
    { Output:string; Number:int }

module FizzBuzzExample2 =

    let handle15 data =
        if (data.Output <> "") then
            data // already processed
        elif (data.Number % 15 <> 0) then
            data // not applicable
        else
            {Output="FizzBuzz"; Number=data.Number}

    let handle3 data =
        if (data.Output <> "") then
            data // already processed
        elif (data.Number % 3 <> 0) then
            data // not applicable
        else
            {Output="Fizz"; Number=data.Number}


    let finalStep data = 
        if data.Output <> "" then
            data.Output // already processed
        else
            data.Number.ToString()

    let fizzBuzzPipeline i =
        {Output=""; Number=i}
        |> handle15
        |> handle3
        |> finalStep

    let fizzBuzz() =
        [1..30]
        |> List.map fizzBuzzPipeline
        |> String.concat ","
        |> printfn "%s"

FizzBuzzExample2.fizzBuzz()

// =============================================
// Demonstrates a generic handler
// =============================================

module FizzBuzzExample3 =
    let finalStep = FizzBuzzExample2.finalStep
    
    /// A generic step
    let handle divisor output data =
        if data.Output <> "" then
            data // already processed
        elif data.Number % divisor <> 0 then
            data // not applicable
        else
            {Output=output; Number=data.Number}

    let logger message data =
        printfn "%s: %A" message data
        data

    let fizzBuzzPipeline i =
        {Output=""; Number=i}
        |> logger "before"
        |> handle 15 "FizzBuzz"
        |> handle 3 "Fizz"
        |> handle 5 "Buzz"
        |> handle 7 "Zap"
        |> logger "after"
        |> finalStep
       

    let fizzBuzz() =
        [1..35]
        |> List.map fizzBuzzPipeline
        |> String.concat ","
        |> printfn "%s"


    fizzBuzz()

FizzBuzzExample3.fizzBuzz()
    

// =============================================
// Demonstrates a parallel fizzbuzz
// =============================================

module FizzBuzzExample4 =
    let handle = FizzBuzzExample3.handle 
    let finalStep = FizzBuzzExample3.finalStep

    let combineData data1 data2 = 
        {Output= data1.Output + data2.Output; Number=data1.Number}

    let fizzBuzzPipeline i =
        
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

    let fizzBuzz() =
        [1..35]
        |> List.map fizzBuzzPipeline
        |> String.concat ","
        |> printfn "%s"

    fizzBuzz()

FizzBuzzExample4.fizzBuzz()
