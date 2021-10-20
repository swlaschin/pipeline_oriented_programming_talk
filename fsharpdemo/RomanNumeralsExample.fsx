
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