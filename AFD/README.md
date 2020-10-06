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

Deterministic Finite Automaton (DFA) In DFA, for each input symbol, one
can determine the state to which the machine will move. Hence, it is
called Deterministic Automaton. As it has a finite number of states, the
machine is called Deterministic Finite Machine or Deterministic Finite
Automaton.

Code section:

// Coding begins here open System open System.Text.RegularExpressions //
Library needed to use Regex class

let mutable symbol = "" // Mutable variables indicate their value can´t
be modify with the "=" symbol, but with the "\<-" operator let mutable
final = ""

let caracter (character) : int = // The "int" indicates the function
will return an ineteger value

    symbol <- ""    // We declare the variables an use de "<-" operator
    final <- ""
    let digit = "[0-9]"
    let operators = "(\+|\-|\*|\/)"

    // Evaluate the string in order to know if the character is a digit, an operator, or none of them.
    if Regex.IsMatch(character, digit) then // The Regex class is used to evaluate and compare the input
        symbol <- "Digit"
        0 

    elif Regex.IsMatch(character, operators) then
        symbol <- "Operator"
        1 

    elif character.Equals(final) then 
        2

    else 
        printfn "The input is incorrect" 
        4
        

let contenido (nextState, character, symbol,state) = // This function
receives variables & prints them. printfn "|\t    %i \t|\t    %c
\t|\t   %s \t|\t %i \t\t|" nextState character symbol state

[<EntryPoint>] // Now that the functions are defined we can continue
with the rest of the code let main argv =

//VARIABLES let table = [[1; 4; 4] ; [4; 2; 4] ; [3; 4; 4] ; [4; 4; 5]]
// This variable corresponds to the transitioin table let mutable state
= 0 // Machine state let mutable c = 0 // Auxiliar variable for the
transition table

printfn "Type a string or expression to evaluate" let cadena =
Console.ReadLine() // Allows the user input printfn ""

for character in cadena do // The loop will evaluate every character in
the entered string let mutable nextState = state c \<- caracter (string
character)

         printfn "+-----------------------+-----------------------+-----------------------+-----------------------+"
         printfn "|\tCurrent State\t|\tCharacter\t|\tSymbol   \t|\tNext State\t|"
        if c < 4  then 
            state <- table.[state].[c]
            if state = 4 then   // The table will be shown if the input is valid
                 printfn "|\t    %i    \t|\t    %c    \t|\t   %s  \t|\t %i   \t\t|" nextState character symbol state
                 printfn "+-----------------------+-----------------------+-----------------------+-----------------------+"
            
        contenido(nextState, character, symbol, state)  // Prints the function with the table content

        if state <> 3 then 
                 printfn "\n\t\t\t\t\tUNVALID INPUT"
        if state = 3 && c < 4 then
                 printfn "|\t    %i    \t|\t          \t|\tEnd of String\t|\t  \t \t|" state
                 printfn "\n\t\t\t\t\tVALID INPUT"
            

0 // return an integer exit code

//CODING ENDS HERE
