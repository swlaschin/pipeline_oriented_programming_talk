
// using a pipe when functions have exactly one parameter
let add1 x = x + 1
let square x = x * x
let double x = x * x

5
|> add1
|> square
|> double


// using a pipe when functions have more than one parameter
let add x y = x + y
let times x y = x * y

5
|> add 1
|> times 2





