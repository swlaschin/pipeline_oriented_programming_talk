

let pipeline list = 
    list
    |> List.map (fun x -> x + 2)
    |> List.filter (fun x -> x > 3)
    |> List.length


