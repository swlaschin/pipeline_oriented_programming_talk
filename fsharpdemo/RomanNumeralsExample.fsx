
// Roman Numerals example

let replace (oldStr:string) (newStr:string) (source:string) = 
    source.Replace(oldStr,newStr)

// Roman numeral without special cases
let toRomanNumerals n =
    String.replicate n "I"
    |> replace "IIIII" "V"
    |> replace "VV" "X"
    |> replace "XXXXX" "L"
    |> replace "LL" "C"

toRomanNumerals 49


// Roman numeral with special cases
let toRomanNumerals2 n =
    String.replicate n "I"
    |> replace "IIIII" "V"
    |> replace "VV" "X"
    |> replace "XXXXX" "L"
    |> replace "LL" "C"
    // special cases
    |> replace "VIIII" "IX"
    |> replace "IIII" "IV"
    |> replace "LXXXX" "XC"
    |> replace "XXXX" "XL"

toRomanNumerals2 49



// a logging function
let log message value =
    printfn $"[{message}] {value}"
    value


// Roman numeral with special cases
let toRomanNumerals3 n =
    String.replicate n "I"
    |> log "start"
    |> replace "IIIII" "V"
    |> replace "VV" "X"
    |> replace "XXXXX" "L"
    |> replace "LL" "C"
    |> log "before special cases"
    // special cases
    |> replace "VIIII" "IX"
    |> replace "IIII" "IV"
    |> replace "LXXXX" "XC"
    |> replace "XXXX" "XL"
    |> log "end"

toRomanNumerals3 49

// ============================
// Decorator pattern
// ============================

let decorateWithLogging fn input =
    input
    |> log "input"   // decorate before
    |> fn            // inner function
    |> log "output"  // decorate after

// create a decorated version
let toRomanNumerals_decorated = 
    decorateWithLogging toRomanNumerals 

// it has the same input and output
// so can be used anywhere the original one was
toRomanNumerals_decorated 49




// TIP the decorator works with ANY function!
let add42 x = x + 42

let add42_decorated = decorateWithLogging add42 

add42_decorated 49



// The log function also works in a pipeline here
49 
|> add42 
|> log "once" 
|> add42 
|> log "twice" 
