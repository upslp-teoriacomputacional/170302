Title: 170302-conjuntos.fs Programming Language: F\# Authors: Edna Paola
Castillo Jara 170302 Subject: Theory of Computation Professor: Juan
Carlos Gónzalez Ibarra Universidad Politecnica de San Luis Potosi

To begin with: Be sure to install Visual Studio, in order to be able to
install it in your PC, you must be a Windows OS user, since Visual
Studio is developed by Microsoft. Otherwise, you can use anothe IDE to
run the file. Continuing with Visual Studio, go to the next link:
https://visualstudio.microsoft.com/es/ and you shoul download the
community 2019 package so it would be easier to acces when it comes to
licenses and permissions. You must have a Microsoft account to log in,
on the contrary, you can register at the moment. Once you are done, you
can open the file.

The code presented below consists on a demonstration and examples of the
use of basic logical operators such as AND, OR, NOT and XOR, in the
already mentioned language: F\#. These operators are represented by &&,
||, not, and ((x || y) && not (x && y)), respectively.

Code section:

// Coding begins here

[<EntryPoint>] let main argv =

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

// Coding ends here
