// =============================================
// Demonstrates the classic FizzBuzz
// =============================================

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


fizzBuzz()
