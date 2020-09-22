// 170302-compuertas.fs
// Programming language: F#

(* Student: Edna Paola Castillo Jara 170302
Universidad Politecnica de San Luis Potosi*)

(* Subject: Theory of Computation
Professor: Juan Carlos Gónzalez Ibarra
  *)

[<EntryPoint>]
let main argv =
    
    // define a list containing the two possible boolean values
    let booleanos= [false; true]

    // Create the truth table for OR
    printfn "\t TRUTH TABLE: OR"
    printfn " x \t y \tx or y"
    printfn "-------------------------"
    for x in booleanos do  // Variable X stands for FALSE
        for y in booleanos do // Variable Y stands for TRUE
            printfn "%A \t%A \t%A \n" x y (x || y) // We use the OR operator

    // Create the truth table for AND    
    printfn "\n\t TRUTH TABLE: AND"
    printfn " x \t y \tx and y"
    printfn "-------------------------"
    for x in booleanos do
        for y in booleanos do
            printfn "%A \t%A \t%A \n" x y (x && y) // We use the AND operator

    //Create the truth table for NOT    
    printfn "\n\t TRUTH TABLE: NOT"
    printfn " x \t not x"
    printfn "-------------------------"
    for x in booleanos do      
         printfn "%A \t%A\n" x (not x) // We use the NOT operator

    printfn " y \t not y"
    printfn "-------------------------"
    for y in booleanos do      
         printfn "%A \t%A\n" y (not y)  // We use the NOT operator

    // Create the truth table for XOR
    printfn "\n\t TRUTH TABLE: XOR"
    printfn " x \t y \tx ^ y"
    printfn "-------------------------"
    for x in booleanos do
        for y in booleanos do
            printfn "%A \t%A \t%A \n" x y ((x || y) && not (x && y)) // If (x OR y) and not (x AND y) is a XOR operation

    0 // return an integer exit code
